using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services.Accounts;

public interface IAccountService
{
    public Task<AccountDto> CreateAccount(AccountDto account);
}