using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
        : base(options){ }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}