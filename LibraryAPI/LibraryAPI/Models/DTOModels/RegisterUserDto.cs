using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOModels;

public class RegisterUserDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}