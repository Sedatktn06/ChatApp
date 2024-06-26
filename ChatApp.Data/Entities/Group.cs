﻿namespace ChatApp.Data.Entities;

public class Group:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Avatar { get; set; }
    #region navigation props
    public ICollection<Message> Messages { get; set; }
    public ICollection<User> Users { get; set; }
    #endregion
}
