namespace LibraryAPI.Models.Repositories;

public class EFBookRepository : ILibraryRepository<Book>
{
    private readonly LibraryDbContext _context;

    public EFBookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    IQueryable<Book> ILibraryRepository<Book>.GetAll => _context.Books;

    public Book? GetItemById(Guid id) => _context.Books.FirstOrDefault(x => x.Id == id);

    public Book? GetBookByIsbn(string isbn) => _context.Books.FirstOrDefault(x => x.ISBN == isbn);

    public Book? AddItem(Book? item)
    {
        if (item == null)
            return null;

        _context.Add(item);
        _context.SaveChanges();

        return item;
    }

    public Book? EditItem(Guid id, Book item)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == id);
        
        if (book == null)
            return null;

        _context.Books.Update(item);
        _context.SaveChanges();

        return item;
    }

    public string DeleteItem(Guid id)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == id);

        if (book == null)
            return "Book doesn't exist";

        _context.Remove(book);
        _context.SaveChanges();

        return $"{book.Name} was successfully deleted";
    }
}