using AutoMapper;
using Zip.Accounts.Core.Dtos;
using Zip.Accounts.Core.Entities;

namespace Zip.Accounts.Services
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<CreateAccountDto, Account>();
        }
    }
}
