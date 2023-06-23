using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers.Accounts;

public class CRMAccountResponseMapper
{
    private readonly IMapper _mapper;

    public CRMAccountResponseMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CRMAccountResponse, Account>()
                .ForMember(dest => dest.Id, 
                    opt => opt.MapFrom(src => src.accountid))
                .ForMember(dest => dest.Name, 
                    opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Phone, 
                    opt => opt.MapFrom(src => src.telephone1))
                .ForMember(dest => dest.Fax, 
                    opt => opt.MapFrom(src => src.fax))
                .ForMember(dest => dest.Website, 
                    opt => opt.MapFrom(src => src.websiteurl))
                .ForMember(dest => dest.ParentAccount, 
                    opt => opt.MapFrom(src => src._parentaccountid_value))
                .ForMember(dest => dest.Ticker, 
                    opt => opt.MapFrom(src => src.tickersymbol))
                .ForMember(dest => dest.RelationshipField, 
                    opt => opt.MapFrom(src => src.customertypecode))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public Account CRMAccountResponseToAccount(CRMAccountResponse crmAccountResponse)
    {
        return _mapper.Map<Account>(crmAccountResponse);
    }

    public CRMAccountResponse AccountToCRMAccountResponse(Account account)
    {
        return _mapper.Map<CRMAccountResponse>(account);
    }
}