using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Contacts;

namespace PESTI_MinimalAPIs.Mappers.Contacts;

public class DeleteContactMapper
{
    private readonly IMapper _mapper;

    public DeleteContactMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ContactIdRequest, CRMDeleteContactId>()
                .ForMember(dest => dest.myp_DeleteContactId, 
                    opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMDeleteContactId ContactIdRequestToCrmDeleteContactId(ContactIdRequest contactIdRequest)
    {
        return _mapper.Map<CRMDeleteContactId>(contactIdRequest);
    }

    public ContactIdRequest CrmDeleteContactIdToContactIdRequest(CRMDeleteContactId crmDeleteContactId)
    {
        return _mapper.Map<ContactIdRequest>(crmDeleteContactId);
    }
}