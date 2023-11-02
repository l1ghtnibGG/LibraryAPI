﻿using LibraryAPI.Models;
using LibraryAPI.Models.DTOModels;
using LibraryAPI.Models.DTOModels.UsersDto;

namespace LibraryAPI.Services;

public interface IUserService
{
    public Task<string?> Register(RegisterUserDto registerUserDto);

    public string? Login(LoginUserDto loginUserDto);
}