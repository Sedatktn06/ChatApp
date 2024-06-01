using ChatApp.Data.Entities;

namespace ChatApp.Data.Repositories.GroupRepositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ChatAppDbContext chatAppDbContext) : base(chatAppDbContext)
    {
    }
}
