using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Contacts;
using PESTI_MinimalAPIs.Contracts.Incidents;

namespace PESTI_MinimalAPIs.Mappers.Incidents;

public class IncidentIdMapper
{
    private readonly IMapper _mapper;

    public IncidentIdMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IncidentIdRequest, CRMIncidentId>()
                .ForMember(dest => dest.myp_IncidentId, 
                    opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMIncidentId IncidentIdRequestToCrmIncidentId(IncidentIdRequest incidentIdRequest)
    {
        return _mapper.Map<CRMIncidentId>(incidentIdRequest);
    }

    public IncidentIdRequest CrmIncidentIdToIncidentIdRequest(CRMIncidentId crmIncidentId)
    {
        return _mapper.Map<IncidentIdRequest>(crmIncidentId);
    }
}