using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers.Incidents;

public class CRMIncidentResponseMapper
{
    private readonly IMapper _mapper;

    public CRMIncidentResponseMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CRMIncidentResponse, Incident>()
                .ForMember(dest => dest.Id, 
                    opt => opt.MapFrom(src => src.incidentid))
                .ForMember(dest => dest.Tile, 
                    opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.SubjectId, 
                    opt => opt.MapFrom(src => src._subjectid_value))
                .ForMember(dest => dest.CustomerId, 
                    opt => opt.MapFrom(src => src._customerid_value))
                .ForMember(dest => dest.Origin, 
                    opt => opt.MapFrom(src => src.caseorigincode))
                .ForMember(dest => dest.ContactId, 
                    opt => opt.MapFrom(src => src._primarycontactid_value))
                .ForMember(dest => dest.Satisfaction, 
                    opt => opt.MapFrom(src => src.customersatisfactioncode))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public Incident CRMIncidentResponseToIncident(CRMIncidentResponse crmIncidentResponse)
    {
        return _mapper.Map<Incident>(crmIncidentResponse);
    }

    public CRMIncidentResponse IncidentToCRMIncidentResponse(Incident incident)
    {
        return _mapper.Map<CRMIncidentResponse>(incident);
    }
}