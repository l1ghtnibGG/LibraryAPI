﻿using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOModels;

public class LoginUserDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}