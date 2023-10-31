namespace LibraryAPI.Models.Repositories;

public interface ILibraryRepository<T> where T : class
{
    public IQueryable<T> GetAll { get; }

    public T? GetItemById(Guid id);

    public T? GetBookByIsbn(string isbn);

    public T? AddItem(T item);

    public T? EditItem(Guid id, T item);

    public string DeleteItem(Guid id);
}