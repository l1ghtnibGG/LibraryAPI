using AutoMapper;
using BusinessLogic.DTOModels.BooksDto;
using BusinessLogic.DTOModels.UsersDto;
using Entities.Models;

namespace BusinessLogic.AutoMapperHelper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();

        CreateMap<BookAddDto, Book>();
        CreateMap<BookEditDto, Book>();
    }
}