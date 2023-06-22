using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Models;
using RestSharp;

namespace PESTI_MinimalAPIs.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly AccountMapper _accountMapper;
    private readonly IConfiguration _configuration;

    public AccountService(IConfiguration configuration)
    {
        _configuration = configuration;
        _accountMapper = new AccountMapper();
    }

    public async Task<AccountDto> CreateAccount(AccountDto account)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_createAccount", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(account);

        var result = await client.ExecuteAsync(request);
        return account;
    }
}
