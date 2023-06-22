using AutoMapper;
using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers;

public class IncidentMapper
{
    private readonly IMapper _mapper;

    public IncidentMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Incident, CRMIncident>()
                .ForMember(dest => dest.myp_IncidentId,
                    opt => opt.MapFrom(src => src.Id))
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
    
    public CRMIncident IncidentToDto(Incident incident)
    {
        // Map an incident to dto
        return _mapper.Map<CRMIncident>(incident);
    }

    public Incident DtoToIncident(CRMIncident crmIncident)
    {
        // Map a dto to incident
        return _mapper.Map<Incident>(crmIncident);
    }
}