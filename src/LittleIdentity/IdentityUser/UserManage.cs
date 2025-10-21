using LittleIdentity.Abstractions.Interfaces.IdentityRole.Repositories;
using LittleIdentity.Abstractions.Interfaces.IdentityUsers.Manager;
using LittleIdentity.Abstractions.Interfaces.IdentityUsers.Repositories;

namespace LitleIdentity.IdentityUser;

public class UserManage<TUser> : IManagerUser<TUser>  
    where TUser : LittleIdentity.Abstractions.Entities.IdentityUser
{
    
    private readonly IRepositoryRole _repositoryRole;
    private readonly IRepositoryUser<TUser> _repositoryUser;

    public UserManage(IRepositoryUser<TUser> repositoryUser, IRepositoryRole repositoryRole)
    {
        _repositoryUser = repositoryUser;
        _repositoryRole = repositoryRole;
    }

    public async Task<TUser?> FindByNameAsync(string userName)
    {
        try
        {
            var user = await _repositoryUser.GetByPredicate(x=>x.Name == userName);
            return user;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<TUser?> FindByEmailAsync(string email)
    {
        
        try
        {
            var user = await _repositoryUser.GetByPredicate
                (x=>x.Email.Address == email);
            return user;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> CreateUserAsync(TUser user, IEnumerable<string> roles)
    {
        try
        {
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashPassword;
            await _repositoryUser.Create(user);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateUserAsync(TUser user, IEnumerable<string> roles)
    {
        try
        {
            if(await _repositoryUser.GetByPredicate(x=>x.Id == user.Id) is null)
                return false;
            await _repositoryUser.Update(user);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeleteUserAsync(TUser user, IEnumerable<string> roles)
    {
        try
        {
            if(await _repositoryUser.GetByPredicate(x=>x.Id == user.Id) is null)
                return false;
            await _repositoryUser.Delete(user);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> AddRoleInUser(int userId, string roleName)
    {
        try
        {
            var user = await _repositoryUser.GetByPredicate(x=>x.Id == userId);
            var role = await _repositoryRole.GetByPredicate(x => x.Title == roleName);
        
            if(user is null || role is null)
                return false;
            user.Roles.Add(role);
            await _repositoryUser.Update(user);
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> ValidatePasswordAsync(TUser user, string password)
    {
        var userExisting = await FindByNameAsync(user.Name);
        if(userExisting is null)
            return false;
        if(!BCrypt.Net.BCrypt.Verify(password, userExisting.Password))
            return false;
        return true;
    }
}