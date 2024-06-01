using ChatApp.Data.Repositories;
using ChatApp.Data.Repositories.GroupRepositories;
using ChatApp.Data.Repositories.MessageRepositories;
using ChatApp.Data.Repositories.UserRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Data;

public static class RegisterRepositories
{
    public static void RegisterRepository(this IServiceCollection repositories)
    {
        repositories.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        repositories.AddScoped<IMessageRepository, MessageRepository>();
        repositories.AddScoped<IGroupRepository, GroupRepository>();
        repositories.AddScoped<IUserRepository, UserRepository>();
    }
}
