using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Contacts;

namespace PESTI_MinimalAPIs.Mappers.Contacts;

public class ContactIdMapper
{
    private readonly IMapper _mapper;

    public ContactIdMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ContactIdRequest, CRMContactId>()
                .ForMember(dest => dest.myp_ContactId, 
                    opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMContactId ContactIdRequestToCrmContactId(ContactIdRequest contactIdRequest)
    {
        return _mapper.Map<CRMContactId>(contactIdRequest);
    }

    public ContactIdRequest CrmContactIdToContactIdRequest(CRMContactId crmContactId)
    {
        return _mapper.Map<ContactIdRequest>(crmContactId);
    }
}