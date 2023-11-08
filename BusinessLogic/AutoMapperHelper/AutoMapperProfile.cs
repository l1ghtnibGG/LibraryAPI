using AutoMapper;
using BusinessLogic.DTOModels.BooksDto;
using Entities.Models;
using LibraryAPI.Models.DTOModels;
using LibraryAPI.Models.DTOModels.UsersDto;

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