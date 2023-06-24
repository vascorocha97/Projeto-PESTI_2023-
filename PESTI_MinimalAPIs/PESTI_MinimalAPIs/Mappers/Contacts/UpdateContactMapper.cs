using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Contacts;

namespace PESTI_MinimalAPIs.Mappers.Contacts;

public class UpdateContactMapper
{
    private readonly IMapper _mapper;

    public UpdateContactMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UpdateContactRequest, CRMUpdateContactRequest>()
                .ForMember(dest => dest.myp_UpdateContactId, 
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.myp_UpdateConctactFirstName, 
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.myp_UpdateConctactLastName, 
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.myp_UpdateConctactJobTitle, 
                    opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.myp_UpdateContactAccountId, 
                    opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.myp_UpdateContactEmail, 
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.myp_UpdateContactPhone, 
                    opt => opt.MapFrom(src => src.Phone))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMUpdateContactRequest UpdateContactRequestToCRMUpdateContactRequest(UpdateContactRequest updateContactRequest)
    {
        return _mapper.Map<CRMUpdateContactRequest>(updateContactRequest);
    }

    public UpdateContactRequest CRMUpdateContactRequestToUpdateContactRequest(CRMUpdateContactRequest crmUpdateContactRequest)
    {
        return _mapper.Map<UpdateContactRequest>(crmUpdateContactRequest);
    }
}