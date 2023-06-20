using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly AccountMapper _accountMapper;

    public AccountService()
    {
        _accountMapper = new AccountMapper();
    }

    public Account CreateAccount(AccountDto accountDto)
    {
        Account account = _accountMapper.DtoToAccount(accountDto);
        
        //plugin
        
        return account;
    }
}