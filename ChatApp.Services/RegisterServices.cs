using ChatApp.Services.Services.GroupServices;
using ChatApp.Services.Services.MessageServices;
using ChatApp.Services.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Services;

public static class RegisterServices
{
    public static void RegisterService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IMessageService, MessageService>();
    }
}
