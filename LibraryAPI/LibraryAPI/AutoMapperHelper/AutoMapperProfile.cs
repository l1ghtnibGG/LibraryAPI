using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTOModels;

namespace LibraryAPI.AutoMapperHelper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();
    }
}