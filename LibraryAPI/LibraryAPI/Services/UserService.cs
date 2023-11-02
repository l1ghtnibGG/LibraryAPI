using System.Net.Mime;
using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTOModels;
using LibraryAPI.Models.DTOModels.UsersDto;
using LibraryAPI.Models.Repositories;

namespace LibraryAPI.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly ILibraryRepository<User> _userContext;
    private readonly ILogger _logger;
    private readonly IJwtTokenService _jwtToken;

    public UserService(ILibraryRepository<User> userContext, IMapper mapper,
        ILogger<UserService> logger, IJwtTokenService jwtToken)
    {
        _userContext = userContext;
        _mapper = mapper;
        _logger = logger;
        _jwtToken = jwtToken;
    }
    
    public async Task<string?> Register(RegisterUserDto registerUserDto)
    {
        var user = _mapper.Map<User>(registerUserDto);

        if (IsUserExists(user))
        {
            _logger.Log(LogLevel.Error, "User already exists");
            return null;
        }

        if ( await _userContext.AddItem(user) == null)
        {
            _logger.Log(LogLevel.Error, "Incorrect input");
            return null;
        }

        var token = _jwtToken.CreateToken(user);
        
        return token;
    }

    public string? Login(LoginUserDto loginUserDto)
    {
        var user = _mapper.Map<User>(loginUserDto);

        if (!IsUserExists(user))
        {
            _logger.Log(LogLevel.Error, "User doesn't exist");
            return null;
        }

        var matchUser = IsPasswordMatch(user);
        
        if (matchUser == null)
        {
            _logger.Log(LogLevel.Error, "Password or email are wrong");
            return null;
        }

        var token = _jwtToken.CreateToken(matchUser);

        return token;
    }

    private bool IsUserExists(User user) => 
        _userContext.GetAll.FirstOrDefault(x => x.Email == user.Email) != null;

    private User? IsPasswordMatch(User user) =>
        _userContext.GetAll.FirstOrDefault(x => 
            x.Email == user.Email && x.Password == user.Password);
}