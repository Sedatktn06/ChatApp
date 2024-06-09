using AutoMapper;
using Azure;
using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Models;
using ChatApp.Services.Models.UserModels;
using ChatApp.Services.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ReturnModel> GetUsers([FromQuery] PaginationModel paginationModel)
    {
        var users = await _userService.GetAllAsync(paginationModel);
        return new ReturnModel
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Data = _mapper.Map<List<UserResponeModel>>(users),
            Message = "Başarılı",
            Success = true,
            TotalCount = await _userService.CountAsync()
        };
    }

    [HttpGet("{id}")]
    public async Task<ReturnModel> Get(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return new ReturnModel
        {
            Data = _mapper.Map<UserResponeModel>(user),
            Message = "Başarılı",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    [HttpPost]
    public async Task<ReturnModel> AddUser([FromBody] UserCreateModel userCreateModel)
    {
        var newUser = _mapper.Map<User>(userCreateModel); 
        var response = await _userService.AddAsync(newUser);
        return new ReturnModel
        {
            Data = _mapper.Map<UserResponeModel>(response),
            Message = "Kullanıcı başarıyla oluşturuldu",
            StatusCode = System.Net.HttpStatusCode.Created,
            Success = true
        };
    }

    [HttpPut]
    public async Task<ReturnModel> UpdateUser([FromBody] UserUpdateModel userUpdateModel)
    {
        var toUpdateModel = _mapper.Map<User>(userUpdateModel);
        var response = await _userService.UpdateAsync(toUpdateModel);
        return new ReturnModel
        {
            Data = _mapper.Map<UserResponeModel>(response),
            Message = "Kullanıcı başarıyla güncellendi.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    [HttpDelete("{id}")]
    public async Task<ReturnModel> DeleteUser(int id)
    {
        var toDeletModel = await _userService.GetByIdAsync(id);
        await _userService.DeleteAsync(toDeletModel);
        return new ReturnModel
        {
            Message = "Kullanıcı başarıyla silinmiştir.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };

    }
}