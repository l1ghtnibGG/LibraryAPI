using LibraryAPI.Models.DTOModels;
using LibraryAPI.Models.DTOModels.UsersDto;

namespace BusinessLogic.Services.Interfaces;

public interface IUserService
{
    public Task<string?> Register(RegisterUserDto registerUserDto);

    public string? Login(LoginUserDto loginUserDto);
}