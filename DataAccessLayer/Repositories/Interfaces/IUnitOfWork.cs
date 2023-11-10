using Entities.Models;

namespace Entities.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public ILibraryRepository<User> Users { get; }
    public ILibraryRepository<Book> Books { get; }
}