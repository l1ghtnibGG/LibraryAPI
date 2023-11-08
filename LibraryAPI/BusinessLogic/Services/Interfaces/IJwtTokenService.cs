using Entities.Models;

namespace BusinessLogic.Services.Interfaces;

public interface IJwtTokenService
{
    public string CreateToken(User user);
}