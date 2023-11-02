using LibraryAPI.Models.Pagination;

namespace LibraryAPI.Models.Repositories;

public interface ILibraryRepository<T> where T : class
{
    public IQueryable<T> GetAll { get; }

    public IQueryable<T> GetAllWithPagination(PaginationParameters pagination);

    public Task<T?> GetItemById(Guid id);

    public Task<T?> GetBookByIsbn(string isbn);

    public Task<T?> AddItem(T item);

    public Task<T?> EditItem(Guid id, T item);

    public Task<string> DeleteItem(Guid id);
}