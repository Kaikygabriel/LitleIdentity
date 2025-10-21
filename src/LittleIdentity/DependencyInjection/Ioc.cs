using LitleIdentity.IdentityUser;
using LitleIdentity.IdentityUser.Repositories;
using LitleIdentity.Services;
using LittleIdentity.Abstractions.Exceptions;
using LittleIdentity.Abstractions.Interfaces.IdentityUsers.Manager;
using LittleIdentity.Abstractions.Interfaces.IdentityUsers.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LitleIdentity.DependencyInjection;

public static class Ioc
{
    public static IServiceCollection AddLittleIdentity<TUser,TContext>
        (this IServiceCollection services) 
        where TUser : LittleIdentity.Abstractions.Entities.IdentityUser
        where TContext : DbContext
    {       
        services.AddScoped<StartupValidator<TUser, TContext>>();    
        services.AddScoped(typeof(IRepositoryUser<TUser>),typeof(RepositoryUser<TUser>));
        services.AddScoped(typeof(IManagerUser<TUser>), typeof(UserManage<TUser>));
        
        return services;
    }
}