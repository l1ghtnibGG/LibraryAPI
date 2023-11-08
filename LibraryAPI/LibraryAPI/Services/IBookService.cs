using LibraryAPI.Models;
using LibraryAPI.Models.DTOModels.BooksDto;
using LibraryAPI.Models.Pagination;

namespace LibraryAPI.Services;

public interface IBookService
{
    public IQueryable<Book> GetBooks(PaginationParameters paginationParameters);

    public Task<Book?> GetBookById(Guid id);

    public Task<Book?> GetBookByIsbn(string isbn);

    public Task<Book?> AddBook(BookDto book);

    public Task<Book?> EditBook(Guid id, BookDto book);

    public Task<Book?> DeleteBook(Guid id);
}