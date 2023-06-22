using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services.Accounts;

public interface IAccountService
{
    public Task<AccountDto> CreateAccount(AccountDto account);
}