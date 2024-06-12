using ChatApp.Data.Models;
using ChatApp.Models;
using ChatApp.Services.Helpers;
using ChatApp.Services.Models.JwtModels;
using ChatApp.Services.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }
    [HttpPost]
    public async Task<ReturnModel> Login([FromBody] LoginModel loginModel)
    {
        var user = await _userService.GetUserByUserName(loginModel.UserName, loginModel.Password);
        if (user == null)
        {
            return new ReturnModel
            {
                Success = false,
                Message = "Invalıd username or password",
                StatusCode = System.Net.HttpStatusCode.NotFound,
            };
        }
        var tokenModel = new TokenModel
        {
            UserName = user.UserName,
            Role = user.UserName,
            SigninKey = _configuration["Jwt:SigninKey"],
            Audience = _configuration["Jwt:Audience"],
            Issuer = _configuration["Jwt:Issuer"]
        };
        var token = JwtTokenHelper.GenerateToken(tokenModel);
        return new ReturnModel
        {
            Data = token,
            Message = "Login successful",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }
}
