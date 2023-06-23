using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Contracts.Incidents;

namespace PESTI_MinimalAPIs.Mappers.Accounts;

public class CreateAccountMapper
{
    private readonly IMapper _mapper;

    public CreateAccountMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateAccountRequest, CRMAccount>()
                .ForMember(dest => dest.myp_AccountName, 
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.myp_AccountPhone, 
                    opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.myp_AccountFax, 
                    opt => opt.MapFrom(src => src.Fax))
                .ForMember(dest => dest.myp_AccountWebsite, 
                    opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.myp_ParentAccountId, 
                    opt => opt.MapFrom(src => src.ParentAccount))
                .ForMember(dest => dest.myp_AccountTicker, 
                    opt => opt.MapFrom(src => src.Ticker))
                .ForMember(dest => dest.myp_RelationshipField, 
                    opt => opt.MapFrom(src => src.RelationshipField))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMAccount CreateAccountRequestToCRMAccount(CreateAccountRequest createAccountRequest)
    {
        return _mapper.Map<CRMAccount>(createAccountRequest);
    }

    public CreateAccountRequest CRMAccountToCreateAccountRequest(CRMAccount crmAccount)
    {
        return _mapper.Map<CreateAccountRequest>(crmAccount);
    }
}