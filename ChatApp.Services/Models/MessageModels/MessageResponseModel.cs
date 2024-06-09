using ChatApp.Data.Entities;

namespace ChatApp.Services.Models.MessageModels;

public record MessageResponseModel
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int? UserId { get; set; }
    public int? GroupId { get; set; }
}
