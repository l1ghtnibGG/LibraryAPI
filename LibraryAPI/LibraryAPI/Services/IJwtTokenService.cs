using LibraryAPI.Models;

namespace LibraryAPI.Services;

public interface IJwtTokenService
{
    public string CreateToken(User user);
}