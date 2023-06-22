using AutoMapper;
using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Mappers
{
    public class AccountMapper
    {
        private readonly IMapper _mapper;

        public AccountMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountDto>()
                    .ForMember(dest => dest.myp_AccountName, 
                        opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.myp_AccountPhone, 
                        opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.myp_AccountFax, 
                        opt => opt.MapFrom(src => src.Fax))
                    .ForMember(dest => dest.myp_AccountWebsite, 
                        opt => opt.MapFrom(src => src.Website))
                    .ForMember(dest => dest.myp_ParentAccountId, 
                        opt => opt.MapFrom(src => src.ParentAccount))
                    .ForMember(dest => dest.myp_AccountTicker, 
                        opt => opt.MapFrom(src => src.Ticker))
                    .ForMember(dest => dest.myp_RelationshipField, 
                        opt => opt.MapFrom(src => src.RelationshipField))
                    .ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public AccountDto AccountToDto(Account account)
        {
            // Map an account to dto
            return _mapper.Map<AccountDto>(account);
        }

        public Account DtoToAccount(AccountDto accountDto)
        {
            // Map a dto to account
            return _mapper.Map<Account>(accountDto);
        }
    }
}