using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTOModels;
using LibraryAPI.Models.DTOModels.BooksDto;
using LibraryAPI.Models.DTOModels.UsersDto;

namespace LibraryAPI.AutoMapperHelper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();

        CreateMap<BookDto, Book>();
    }
}