using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Contracts.Contacts;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers.Contacts;

public class CRMContactResponseMapper
{
    private readonly IMapper _mapper;

    public CRMContactResponseMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CRMContactResponse, Contact>()
                .ForMember(dest => dest.Id, 
                    opt => opt.MapFrom(src => src.contactid))
                .ForMember(dest => dest.FirstName, 
                    opt => opt.MapFrom(src => src.firstname))
                .ForMember(dest => dest.LastName, 
                    opt => opt.MapFrom(src => src.lastname))
                .ForMember(dest => dest.JobTitle, 
                    opt => opt.MapFrom(src => src.jobtitle))
                .ForMember(dest => dest.AccountId, 
                    opt => opt.MapFrom(src => src._parentcustomerid_value))
                .ForMember(dest => dest.Email, 
                    opt => opt.MapFrom(src => src.emailaddress1))
                .ForMember(dest => dest.Phone, 
                    opt => opt.MapFrom(src => src.telephone1))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public Contact CRMContactResponseToContact(CRMContactResponse crmContactResponse)
    {
        return _mapper.Map<Contact>(crmContactResponse);
    }

    public CRMContactResponse ContactToCRMContactResponse(Contact contact)
    {
        return _mapper.Map<CRMContactResponse>(contact);
    }
}