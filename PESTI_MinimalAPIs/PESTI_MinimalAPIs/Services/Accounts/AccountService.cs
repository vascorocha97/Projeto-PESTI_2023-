using Newtonsoft.Json;
using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Mappers.Accounts;
using PESTI_MinimalAPIs.Models;
using RestSharp;

namespace PESTI_MinimalAPIs.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly CRMAccountResponseMapper _crmAccountResponseMapper;
    private readonly IConfiguration _configuration;

    public AccountService(IConfiguration configuration)
    {
        _configuration = configuration;
        _crmAccountResponseMapper = new CRMAccountResponseMapper();
    }

    public async Task<Account?> CreateAccount(CRMAccount crmAccount)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_createAccount", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(crmAccount);

        var result = await client.ExecuteAsync(request);

        if (!result.IsSuccessStatusCode) return null;
        
        var createdAccount = JsonConvert.DeserializeObject<CRMAccountResponse>(result.Content!);
        return createdAccount is null ? null : _crmAccountResponseMapper.CRMAccountResponseToAccount(createdAccount);
    }
}
