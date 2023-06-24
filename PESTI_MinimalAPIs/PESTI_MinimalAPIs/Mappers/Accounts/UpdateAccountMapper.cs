using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;

namespace PESTI_MinimalAPIs.Mappers.Accounts;

public class UpdateAccountMapper
{
    private readonly IMapper _mapper;

    public UpdateAccountMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UpdateAccountRequest, CRMUpdateAccountRequest>()
                .ForMember(dest => dest.myp_UpdateAccountId, 
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.myp_UpdateAccountName, 
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.myp_UpdateAccountPhone, 
                    opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.myp_UpdateAccountFax, 
                    opt => opt.MapFrom(src => src.Fax))
                .ForMember(dest => dest.myp_UpdateAccountWebsite, 
                    opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.myp_UpdateParentAccountId, 
                    opt => opt.MapFrom(src => src.ParentAccount))
                .ForMember(dest => dest.myp_UpdateAccountTicker, 
                    opt => opt.MapFrom(src => src.Ticker))
                .ForMember(dest => dest.myp_UpdateRelationshipField, 
                    opt => opt.MapFrom(src => src.RelationshipField))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMUpdateAccountRequest UpdateAccountRequestToCRMUpdateAccountRequest(UpdateAccountRequest updateAccountRequest)
    {
        return _mapper.Map<CRMUpdateAccountRequest>(updateAccountRequest);
    }

    public UpdateAccountRequest CRMUpdateAccountRequestToUpdateAccountRequest(CRMUpdateAccountRequest crmUpdateAccountRequest)
    {
        return _mapper.Map<UpdateAccountRequest>(crmUpdateAccountRequest);
    }
}