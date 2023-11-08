using Entities.Models;
using Entities.Repositories.Interfaces;
using Entities.Repositories.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Entities.Repositories.Implementations;

public class EFUserRepository : ILibraryRepository<User>
{
    private readonly LibraryDbContext _context;

    public EFUserRepository(LibraryDbContext context)
    {
        _context = context;
    }

    IQueryable<User> ILibraryRepository<User>.GetAll => _context.Users;

    public IQueryable<User> GetAllWithPagination(PaginationParameters pagination) =>
        _context.Users.OrderBy(x => x.Email)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize);

    public async Task<User?> GetItemById(Guid id) => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

    public Task<User?> GetBookByIsbn(string isbn)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> AddItem(User? item)
    {
        if (item == null)
            return null;

        _context.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<User?>EditItem(Guid id, User item)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        
        if (user == null)
            return null;

        _context.Users.Update(item);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> DeleteItem(Guid id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
            return null;

        _context.Remove(user);
        await _context.SaveChangesAsync();

        return user;
    }
}