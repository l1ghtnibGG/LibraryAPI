using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.EF;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
        : base(options){ }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}