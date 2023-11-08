using BusinessLogic.Services.Interfaces;
using LibraryAPI.Models.DTOModels;
using LibraryAPI.Models.DTOModels.UsersDto;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("[controller]/")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    /// <summary>
    /// Register a new user
    /// </summary>
    /// <param name="registerUserDto">The user information of registration</param>
    /// <returns>JWT token.</returns>
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody]RegisterUserDto registerUserDto)
    {
        var token = await _userService.Register(registerUserDto);

        if (token == null)
            return BadRequest(token);

        return Ok(token);
    }
    
    /// <summary>
    /// Log in a user
    /// </summary>
    /// <param name="loginUserDto">The user information of login.</param>
    /// <returns>Jwt token</returns>
    [HttpPost("login")]
    public ActionResult Login([FromBody]LoginUserDto loginUserDto)
    {
        var token = _userService.Login(loginUserDto);

        if (token == null)
            return BadRequest(token);

        return Ok(token);
    }
}