using AutoMapper;
using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers;

public class ContactMapper
{
    private readonly IMapper _mapper;

    public ContactMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Contact, ContactDto>()
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
                    opt => opt.MapFrom(src => src.Phone));
        });

        _mapper = config.CreateMapper();
    }
    
    public ContactDto ContactToDto(Contact contact)
    {
        // Map an account to dto
        return _mapper.Map<ContactDto>(contact);
    }

    public Contact DtoToContact(ContactDto contactDto)
    {
        // Map a dto to account
        return _mapper.Map<Contact>(contactDto);
    }
}