using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Incidents;

namespace PESTI_MinimalAPIs.Mappers.Incidents;

public class DeleteIncidentMapper
{
    private readonly IMapper _mapper;

    public DeleteIncidentMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IncidentIdRequest, CRMDeleteIncidentId>()
                .ForMember(dest => dest.myp_DeleteIncidentId, 
                    opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMDeleteIncidentId IncidentIdRequestToCrmDeleteIncidentId(IncidentIdRequest incidentIdRequest)
    {
        return _mapper.Map<CRMDeleteIncidentId>(incidentIdRequest);
    }

    public IncidentIdRequest CrmDeleteIncidentIdToIncidentIdRequest(CRMDeleteIncidentId crmDeleteIncidentId)
    {
        return _mapper.Map<IncidentIdRequest>(crmDeleteIncidentId);
    }
}