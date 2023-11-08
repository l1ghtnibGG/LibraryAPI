using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string ISBN { get; set; }
    
    public string Name { get; set; }
    
    public string Genre { get; set; }
    
    public string Description { get; set; }
    
    public string Author { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime DateOfTake { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime DateOfReturn { get; set; }
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}