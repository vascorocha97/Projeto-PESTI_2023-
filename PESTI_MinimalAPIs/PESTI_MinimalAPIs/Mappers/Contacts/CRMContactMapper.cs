using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Contacts;

namespace PESTI_MinimalAPIs.Mappers.Contacts;

public class CRMContactMapper
{
    private readonly IMapper _mapper;

    public CRMContactMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CRMContact, CRMContactResponse>()
                .ForMember(dest => dest.firstname, 
                    opt => opt.MapFrom(src => src.myp_ConctactFirstName))
                .ForMember(dest => dest.lastname, 
                    opt => opt.MapFrom(src => src.myp_ConctactLastName))
                .ForMember(dest => dest.jobtitle, 
                    opt => opt.MapFrom(src => src.myp_ConctactJobTitle))
                .ForMember(dest => dest._parentcustomerid_value, 
                    opt => opt.MapFrom(src => src.myp_ContactAccountId))
                .ForMember(dest => dest.emailaddress1, 
                    opt => opt.MapFrom(src => src.myp_ContactEmail))
                .ForMember(dest => dest.telephone1, 
                    opt => opt.MapFrom(src => src.myp_ContactPhone))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMContactResponse CrmContactToCrmContactResponse(CRMContact crmContact)
    {
        return _mapper.Map<CRMContactResponse>(crmContact);
    }

    public CRMContact CRMContactResponseToCRMContact(CRMContactResponse crmContactResponse)
    {
        return _mapper.Map<CRMContact>(crmContactResponse);
    }
}