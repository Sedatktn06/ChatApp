using ChatApp.Data.Entities;

namespace ChatApp.Services.Services.UserServices;

public interface IUserService:IGenericService<User>
{
    public Task<User> GetUserByUserName(string userName, string password);
}
