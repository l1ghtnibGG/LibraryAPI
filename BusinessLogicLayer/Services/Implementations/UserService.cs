using AutoMapper;
using BusinessLogic.DTOModels.UsersDto;
using BusinessLogic.Exceptions;
using BusinessLogic.Services.Interfaces;
using Entities.Models;
using Entities.Repositories.Interfaces;

namespace BusinessLogic.Services.Implementations;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenService _jwtToken;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, 
        IJwtTokenService jwtToken)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtToken = jwtToken;
    }
    
    public async Task<string?> Register(RegisterUserDto registerUserDto)
    {
        var user = _mapper.Map<User>(registerUserDto);

        if (IsUserExists(user))
            throw new ValidateException("User already exists");

        if (await _unitOfWork.Users.AddItem(user) == null)
            throw new ValidateException("Wrong input");
        
        return _jwtToken.CreateToken(user);
    }

    public string? Login(LoginUserDto loginUserDto)
    {
        var user = _mapper.Map<User>(loginUserDto);

        if (!IsUserExists(user))
            throw new ValidateException("User doesn't exist");

        var matchUser = IsPasswordMatch(user);
        
        if (matchUser == null)
            throw new ValidateException("Password or email are wrong");
        
        return _jwtToken.CreateToken(matchUser);
    }

    private bool IsUserExists(User user) => 
        _unitOfWork.Users.GetAll.FirstOrDefault(x => x.Email == user.Email) != null;

    private User? IsPasswordMatch(User user) =>
        _unitOfWork.Users.GetAll.FirstOrDefault(x => 
            x.Email == user.Email && x.Password == user.Password);
}