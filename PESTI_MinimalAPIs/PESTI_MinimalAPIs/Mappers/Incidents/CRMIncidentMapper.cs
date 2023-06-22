using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Incidents;

namespace PESTI_MinimalAPIs.Mappers.Incidents;

public class CRMIncidentMapper
{
    private readonly IMapper _mapper;

    public CRMIncidentMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CRMIncident, CRMIncidentResponse>()
                .ForMember(dest => dest.title, 
                    opt => opt.MapFrom(src => src.myp_IncidentTile))
                .ForMember(dest => dest._subjectid_value, 
                    opt => opt.MapFrom(src => src.myp_IncidentSubjectId))
                .ForMember(dest => dest._customerid_value, 
                    opt => opt.MapFrom(src => src.myp_IncidentCustomerId))
                .ForMember(dest => dest.caseorigincode, 
                    opt => opt.MapFrom(src => src.myp_IncidentOrigin))
                .ForMember(dest => dest._primarycontactid_value, 
                    opt => opt.MapFrom(src => src.myp_IncidentContactId))
                .ForMember(dest => dest.customersatisfactioncode, 
                    opt => opt.MapFrom(src => src.myp_IncidentSatisfaction))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMIncidentResponse CrmIncidentToCrmIncidentResponse(CRMIncident crmIncident)
    {
        return _mapper.Map<CRMIncidentResponse>(crmIncident);
    }

    public CRMIncident CRMIncidentResponseToCRMIncident(CRMIncidentResponse crmIncidentResponse)
    {
        return _mapper.Map<CRMIncident>(crmIncidentResponse);
    }
}