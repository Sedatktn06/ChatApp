using AutoMapper;
using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Models;
using ChatApp.Services.Models.GroupModels;
using ChatApp.Services.Models.MessageModels;
using ChatApp.Services.Services.GroupServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;

    public GroupsController(IGroupService groupService, IMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ReturnModel> GetGroups([FromQuery] PaginationModel paginationModel)
    {
        var groups = await _groupService.GetAllAsync(paginationModel);
        return new ReturnModel
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Data = _mapper.Map<List<GroupResponseModel>>(groups),
            Message = "Başarılı",
            Success = true,
            TotalCount = await _groupService.CountAsync()
        };
    }

    [HttpGet("{id}")]
    public async Task<ReturnModel> Get(int id)
    {
        var group = await _groupService.GetByIdAsync(id);
        return new ReturnModel
        {
            Data = _mapper.Map<GroupResponseModel>(group),
            Message = "Başarılı",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    [HttpPost]
    public async Task<ReturnModel> AddGroup([FromBody] GroupCreateModel groupCreateModel)
    {
        var newGroup = _mapper.Map<Group>(groupCreateModel);
        var response = await _groupService.AddAsync(newGroup);
        return new ReturnModel
        {
            Data = _mapper.Map<GroupResponseModel>(response),
            Message = "Grup başarıyla oluşturuldu",
            StatusCode = System.Net.HttpStatusCode.Created,
            Success = true
        };
    }

    [HttpPut]
    public async Task<ReturnModel> UpdateGroup([FromBody] GroupUpdateModel groupUpdateModel)
    {
        var toUpdateModel = _mapper.Map<Group>(groupUpdateModel);
        var response = await _groupService.UpdateAsync(toUpdateModel);
        return new ReturnModel
        {
            Data = _mapper.Map<GroupResponseModel>(response),
            Message = "Grup başarıyla güncellendi.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    [HttpDelete("{id}")]
    public async Task<ReturnModel> DeleteGroup(int id)
    {
        var toDeletModel = await _groupService.GetByIdAsync(id);
        await _groupService.DeleteAsync(toDeletModel);
        return new ReturnModel
        {
            Message = "Grup başarıyla silinmiştir.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };

    }
}
