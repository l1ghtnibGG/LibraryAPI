using BusinessLogic.DTOModels.BooksDto;
using Entities.Models;
using Entities.Pagination;

namespace BusinessLogic.Services.Interfaces;

public interface IBookService
{
    public IQueryable<Book> GetBooks(PaginationParameters paginationParameters);

    public Task<Book?> GetBookById(Guid id);

    public Task<Book?> GetBookByIsbn(string isbn);

    public Task<Book?> AddBook(BookAddDto book);

    public Task<Book?> EditBook(Guid id, BookEditDto book);

    public Task<Book?> DeleteBook(Guid id);
}