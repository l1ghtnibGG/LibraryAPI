using LibraryAPI.Models;
using LibraryAPI.Models.Repositories;

namespace LibraryAPI.Services;

public class BookService : IBookService
{
    private readonly ILibraryRepository<Book> _bookContext;

    public BookService(ILibraryRepository<Book> bookContext) => _bookContext = bookContext;

    public IQueryable<Book> GetBooks() => _bookContext.GetAll;

    public Book? GetBookById(Guid id) => _bookContext.GetItemById(id);

    public Book? GetBookByIsbn(string isbn) => _bookContext.GetBookByIsbn(isbn);

    public Book? AddBook(Book book) => _bookContext.AddItem(book);

    public Book? EditBook(Guid id, Book book) => _bookContext.EditItem(id, book);

    public string DeleteBook(Guid id) => _bookContext.DeleteItem(id);
}