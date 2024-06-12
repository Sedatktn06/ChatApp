using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Data.Repositories.UserRepositories;

namespace ChatApp.Services.Services.UserServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AddAsync(User entity)
    {
        var user = await _userRepository.CreateAsync(entity);
        return user;
    }

    public async Task<int> CountAsync()
    {
        var count = await _userRepository.CountAsync();
        return count;
    }

    public async Task<User> DeleteAsync(User entity)
    {
        var user = await _userRepository.DeleteAsync(entity);
        return user;
    }

    public async Task<IReadOnlyList<User>> GetAllAsync(PaginationModel paginationModel)
    {
        var users = await _userRepository.GetAllAsync(paginationModel);
        return users;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<User> GetUserByUserName(string userName, string password)
    {
        var user = await _userRepository.GetUserByUserName(userName, password);
        return user;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        var user = await _userRepository.UpdateAsync(entity);
        return user;
    }
}
