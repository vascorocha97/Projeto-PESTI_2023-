using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers.Incidents;

public class CreateIncidentMapper
{
    private readonly IMapper _mapper;

    public CreateIncidentMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateIncidentRequest, CRMIncident>()
                .ForMember(dest => dest.myp_IncidentTile, 
                    opt => opt.MapFrom(src => src.Tile))
                .ForMember(dest => dest.myp_IncidentSubjectId, 
                    opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.myp_IncidentCustomerId, 
                    opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.myp_IncidentOrigin, 
                    opt => opt.MapFrom(src => src.Origin))
                .ForMember(dest => dest.myp_IncidentContactId, 
                    opt => opt.MapFrom(src => src.ContactId))
                .ForMember(dest => dest.myp_IncidentSatisfaction, 
                    opt => opt.MapFrom(src => src.Satisfaction))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMIncident CreateIncidentRequestToCRMIncident(CreateIncidentRequest createIncidentRequest)
    {
        return _mapper.Map<CRMIncident>(createIncidentRequest);
    }

    public CreateIncidentRequest CRMIncidentToCreateIncidentRequest(CRMIncident crmIncident)
    {
        return _mapper.Map<CreateIncidentRequest>(crmIncident);
    }
}