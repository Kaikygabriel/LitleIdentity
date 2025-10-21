using LitleIdentity.IdentityUser;
using LitleIdentity.Repositories.IdentityUser;
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
        services.AddScoped(typeof(IRepositoryUser<TUser>),typeof(RepositoryUser<TUser>));
        services.AddScoped(typeof(IManagerUser<TUser>), typeof(UserManage<TUser>));
        services.AddScoped<StartupValidator<TUser, TContext>>();    
        return services;
    }
}