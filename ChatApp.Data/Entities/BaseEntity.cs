using ChatApp.Data.Repositories.UserRepositories;

namespace ChatApp.Data.Entities;
public class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? IsDeleted { get; set; }
}
