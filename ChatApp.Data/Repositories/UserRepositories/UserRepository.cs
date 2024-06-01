using ChatApp.Data.Entities;

namespace ChatApp.Data.Repositories.UserRepositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ChatAppDbContext chatAppDbContext) : base(chatAppDbContext)
    {
    }
}
