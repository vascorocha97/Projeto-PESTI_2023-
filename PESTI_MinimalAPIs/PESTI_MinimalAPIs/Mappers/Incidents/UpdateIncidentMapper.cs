using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Incidents;

namespace PESTI_MinimalAPIs.Mappers.Incidents;

public class UpdateIncidentMapper
{
    private readonly IMapper _mapper;

    public UpdateIncidentMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UpdateIncidentRequest, CRMUpdateIncidentRequest>()
                .ForMember(dest => dest.myp_UpdateIncidentId, 
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.myp_UpdateIncidentTile, 
                    opt => opt.MapFrom(src => src.Tile))
                .ForMember(dest => dest.myp_UpdateIncidentSubjectId, 
                    opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.myp_UpdateIncidentCustomerId, 
                    opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.myp_UpdateIncidentOrigin, 
                    opt => opt.MapFrom(src => src.Origin))
                .ForMember(dest => dest.myp_UpdateIncidentContactId, 
                    opt => opt.MapFrom(src => src.ContactId))
                .ForMember(dest => dest.myp_UpdateIncidentSatisfaction, 
                    opt => opt.MapFrom(src => src.Satisfaction))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMUpdateIncidentRequest UpdateIncidentRequestToCRMUpdateIncidentRequest(UpdateIncidentRequest updateIncidentRequest)
    {
        return _mapper.Map<CRMUpdateIncidentRequest>(updateIncidentRequest);
    }

    public UpdateIncidentRequest CRMUpdateIncidentRequestToUpdateIncidentRequest(CRMUpdateIncidentRequest crmUpdateIncidentRequest)
    {
        return _mapper.Map<UpdateIncidentRequest>(crmUpdateIncidentRequest);
    }
}