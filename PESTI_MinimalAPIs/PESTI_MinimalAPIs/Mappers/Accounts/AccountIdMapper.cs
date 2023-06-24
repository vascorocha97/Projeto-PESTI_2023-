using AutoMapper;
using PESTI_MinimalAPIs.Contracts.Accounts;

namespace PESTI_MinimalAPIs.Mappers.Accounts;

public class AccountIdMapper
{
    private readonly IMapper _mapper;

    public AccountIdMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountIdRequest, CRMAccountId>()
                .ForMember(dest => dest.myp_AccountId, 
                    opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public CRMAccountId AccountIdRequestToCrmAccountId(AccountIdRequest accountIdRequest)
    {
        return _mapper.Map<CRMAccountId>(accountIdRequest);
    }

    public AccountIdRequest CrmAccountIdToAccountIdRequest(CRMAccountId crmAccountId)
    {
        return _mapper.Map<AccountIdRequest>(crmAccountId);
    }
}