using AutoMapper;
using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers;

public class AccountMapper
{
    private readonly IMapper _mapper;

    public AccountMapper()
    {
        var config = new MapperConfiguration(config => config.CreateMap<Account, AccountDto>());
        _mapper = config.CreateMapper();
    }

    public AccountDto AccountToDto(Account account)
    {
        //map an account to dto
        return _mapper.Map<AccountDto>(account);
    }

    public Account DtoToAccount(AccountDto accountDto)
    {
        //map a dto to account
        return _mapper.Map<Account>(accountDto);
    }
}
