using ChatApp.Data.Entities;

namespace ChatApp.Data.Repositories.UserRepositories;

public interface IUserRepository:IGenericRepository<User>
{
    public Task<User> GetUserByUserName(string userName,string password);
}
