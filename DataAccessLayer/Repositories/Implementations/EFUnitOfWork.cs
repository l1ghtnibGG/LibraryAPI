using Entities.EF;
using Entities.Models;
using Entities.Repositories.Interfaces;

namespace Entities.Repositories.Implementations;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _context;
    private EFBookRepository _bookRepository;
    private EFUserRepository _userRepository;
    private bool _isDisposed;

    public EFUnitOfWork(LibraryDbContext context) 
        => _context = context;

    public ILibraryRepository<User> Users 
        => _userRepository ??= new EFUserRepository(_context);

    public ILibraryRepository<Book> Books 
        => _bookRepository ??= new EFBookRepository(_context);
    
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
            return;

        if (disposing)
            _context.Dispose();

        _isDisposed = true;
    }
}