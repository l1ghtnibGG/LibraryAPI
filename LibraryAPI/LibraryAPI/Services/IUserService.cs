using LibraryAPI.Models;
using LibraryAPI.Models.DTOModels;

namespace LibraryAPI.Services;

public interface IUserService
{
    public string? Register(RegisterUserDto registerUserDto);

    public string? Login(LoginUserDto loginUserDto);
}