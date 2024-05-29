namespace ChatApp.Data.Entities;

public class Message:BaseEntity
{
    public string Content { get; set; }
    public int? UserId { get; set; }
    public int? GroupId { get; set; }
    #region navigation props
    public User User { get; set; }
    public Group Group { get; set; }
    #endregion
}
