namespace ChatApp.Services.Models.GroupModels;

public record GroupResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Avatar { get; set; }
}
