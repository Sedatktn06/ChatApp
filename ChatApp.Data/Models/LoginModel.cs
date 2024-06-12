namespace ChatApp.Data.Models;

public record LoginModel
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
