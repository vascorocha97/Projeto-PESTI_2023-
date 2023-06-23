using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Contracts.Contacts;

namespace PESTI_MinimalAPIs.Mappers.Contacts;

public class CreateContactMapper
{
    private readonly IMapper _mapper;

    public CreateContactMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateContactRequest, CRMContact>()
                .ForMember(dest => dest.myp_ConctactFirstName, 
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.myp_ConctactLastName, 
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.myp_ConctactJobTitle, 
                    opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.myp_ContactAccountId, 
                    opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.myp_ContactEmail, 
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.myp_ContactPhone, 
                    opt => opt.MapFrom(src => src.Phone))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMContact CreateContactRequestToCRMContact(CreateContactRequest createContactRequest)
    {
        return _mapper.Map<CRMContact>(createContactRequest);
    }

    public CreateContactRequest CRMContactToCreateContactRequest(CRMContact crmContact)
    {
        return _mapper.Map<CreateContactRequest>(crmContact);
    }
}