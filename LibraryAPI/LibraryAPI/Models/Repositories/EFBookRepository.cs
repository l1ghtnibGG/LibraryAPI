using LibraryAPI.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models.Repositories;

public class EFBookRepository : ILibraryRepository<Book>
{
    private readonly LibraryDbContext _context;

    public EFBookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    IQueryable<Book> ILibraryRepository<Book>.GetAll => _context.Books;

    public IQueryable<Book> GetAllWithPagination(PaginationParameters pagination) =>
        _context.Books.OrderBy(x => x.Name)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize);

    public async Task<Book?> GetItemById(Guid id) => await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Book?> GetBookByIsbn(string isbn) => await _context.Books.FirstOrDefaultAsync(x => x.ISBN == isbn);

    public async Task<Book?> AddItem(Book? item)
    {
        if (item == null)
            return null;

        _context.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<Book?> EditItem(Guid id, Book item)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == id);
        
        if (book == null)
            return null;

        _context.Books.Update(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<Book?> DeleteItem(Guid id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        if (book == null)
            return null;

        _context.Remove(book);
        await _context.SaveChangesAsync();

        return book;
    }
}
