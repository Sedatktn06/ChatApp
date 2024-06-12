using ChatApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Data.Repositories.UserRepositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ChatAppDbContext _chatAppDbContext;
    public UserRepository(ChatAppDbContext chatAppDbContext) : base(chatAppDbContext)
    {
        _chatAppDbContext = chatAppDbContext;
    }

    public async Task<User> GetUserByUserName(string userName, string password)
    {
        var user = await _chatAppDbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
        return user;
    }
}
