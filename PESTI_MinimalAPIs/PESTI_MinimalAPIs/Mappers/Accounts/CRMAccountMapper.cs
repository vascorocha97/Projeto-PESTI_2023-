using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Contracts.Incidents;

namespace PESTI_MinimalAPIs.Mappers.Accounts;

public class CRMAccountMapper
{
    private readonly IMapper _mapper;

    public CRMAccountMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CRMAccount, CRMAccountResponse>()
                .ForMember(dest => dest.name, 
                    opt => opt.MapFrom(src => src.myp_AccountName))
                .ForMember(dest => dest.telephone1, 
                    opt => opt.MapFrom(src => src.myp_AccountPhone))
                .ForMember(dest => dest.fax, 
                    opt => opt.MapFrom(src => src.myp_AccountFax))
                .ForMember(dest => dest.websiteurl, 
                    opt => opt.MapFrom(src => src.myp_AccountWebsite))
                .ForMember(dest => dest._parentaccountid_value, 
                    opt => opt.MapFrom(src => src.myp_ParentAccountId))
                .ForMember(dest => dest.tickersymbol, 
                    opt => opt.MapFrom(src => src.myp_AccountTicker))
                .ForMember(dest => dest.customertypecode, 
                    opt => opt.MapFrom(src => src.myp_RelationshipField))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMAccountResponse CrmAccountToCrmAccountResponse(CRMAccount crmAccount)
    {
        return _mapper.Map<CRMAccountResponse>(crmAccount);
    }

    public CRMAccount CRMAccountResponseToCRMAccount(CRMAccountResponse crmAccountResponse)
    {
        return _mapper.Map<CRMAccount>(crmAccountResponse);
    }
}