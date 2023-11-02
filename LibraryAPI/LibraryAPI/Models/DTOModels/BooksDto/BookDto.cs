namespace LibraryAPI.Models.DTOModels.BooksDto;

public class BookDto
{
    public Guid Id { get; set; }
    
    public string ISBN { get; set; }
    
    public string Name { get; set; }
    
    public string Genre { get; set; }
    
    public string Description { get; set; }
    
    public string Author { get; set; }
    
    public DateTime DateOfTake { get; set; }
    
    public DateTime DateOfReturn { get; set; }
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}