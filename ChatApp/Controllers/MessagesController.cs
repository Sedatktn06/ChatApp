using AutoMapper;
using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Models;
using ChatApp.Services.Models.MessageModels;
using ChatApp.Services.Services.MessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public MessagesController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ReturnModel> GetMessages([FromQuery] PaginationModel paginationModel)
    {
        var messages = await _messageService.GetAllAsync(paginationModel);
        return new ReturnModel
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Data = _mapper.Map<List<MessageResponseModel>>(messages),
            Message = "Başarılı",
            Success = true,
            TotalCount = await _messageService.CountAsync()
        };
    }

    [HttpGet("{id}")]
    public async Task<ReturnModel> Get(int id)
    {
        var message = await _messageService.GetByIdAsync(id);
        return new ReturnModel
        {
            Data = _mapper.Map<MessageResponseModel>(message),
            Message = "Başarılı",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    [HttpPost]
    public async Task<ReturnModel> AddMessage([FromBody] MessageCreateModel messageCreateModel)
    {
        var newMessage = _mapper.Map<Message>(messageCreateModel);
        var response = await _messageService.AddAsync(newMessage);
        return new ReturnModel
        {
            Data = _mapper.Map<MessageResponseModel>(response),
            Message = "Mesaj başarıyla oluşturuldu",
            StatusCode = System.Net.HttpStatusCode.Created,
            Success = true
        };
    }

    [HttpPut]
    public async Task<ReturnModel> UpdateMessage([FromBody] MessageUpdateModel messageUpdateModel)
    {
        var toUpdateModel = _mapper.Map<Message>(messageUpdateModel);
        var response = await _messageService.UpdateAsync(toUpdateModel);
        return new ReturnModel
        {
            Data = _mapper.Map<MessageResponseModel>(response),
            Message = "Mesaj başarıyla güncellendi.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    [HttpDelete("{id}")]
    public async Task<ReturnModel> DeleteMessage(int id)
    {
        var toDeletModel = await _messageService.GetByIdAsync(id);
        await _messageService.DeleteAsync(toDeletModel);
        return new ReturnModel
        {
            Message = "Mesaj başarıyla silinmiştir.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };

    }
}
