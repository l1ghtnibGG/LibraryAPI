using LibraryAPI.Models;

namespace LibraryAPI.Services;

public interface IBookService
{
    public IQueryable<Book> GetBooks();

    public Book? GetBookById(Guid id);

    public Book? GetBookByIsbn(string isbn);

    public Book? AddBook(Book book);

    public Book? EditBook(Guid id, Book book);

    public string DeleteBook(Guid id);
}