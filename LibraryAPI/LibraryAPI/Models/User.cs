using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public List<Book> Books { get; } = new();
}