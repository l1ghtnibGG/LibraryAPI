namespace LibraryAPI.Models.Repositories;

public class EFUserRepository : ILibraryRepository<User>
{
    private readonly LibraryDbContext _context;

    public EFUserRepository(LibraryDbContext context)
    {
        _context = context;
    }

    IQueryable<User> ILibraryRepository<User>.GetAll => _context.Users;

    public User? GetItemById(Guid id) => _context.Users.FirstOrDefault(x => x.Id == id);

    public User? GetBookByIsbn(string isbn)
    {
        throw new NotImplementedException();
    }

    public User? AddItem(User? item)
    {
        if (item == null)
            return null;

        _context.Add(item);
        _context.SaveChanges();

        return item;
    }

    public User? EditItem(Guid id, User item)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        
        if (user == null)
            return null;

        _context.Users.Update(item);
        _context.SaveChanges();

        return user;
    }

    public string DeleteItem(Guid id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
            return "User doesn't exist";

        _context.Remove(user);
        _context.SaveChanges();

        return $"{user.Name} was successfully deleted";
    }
}