using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services.Accounts;

public interface IAccountService
{
    public Task<Account?> CreateAccount(CRMAccount crmAccount);
    public Task<List<Account>?> GetAllAccounts();
    public Task<Account?> GetAccountById(CRMAccountId crmAccountId);
    public Task<Account?> UpdateAccount(CRMUpdateAccountRequest crmUpdateAccountRequest);
}