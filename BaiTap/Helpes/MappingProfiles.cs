using AutoMapper;
using BaiTap.Dto;
using BaiTap.Models;

namespace BaiTap.Helpes
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<User , UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
