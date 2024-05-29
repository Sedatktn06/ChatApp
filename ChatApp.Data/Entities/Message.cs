namespace ChatApp.Data.Entities;

public class Message:BaseEntity
{
    public string Content { get; set; }
    public string UserId { get; set; }
    public string? GroupId { get; set; }
    public User User { get; set; }
}
