using LittleIdentity.Abstractions.Entities;

namespace LittleIdentity.Abstractions.Interfaces.IdentityUsers.Manager;

public interface IManagerUser<TUser> where TUser : IdentityUser
{
    Task<TUser?> FindByNameAsync(string userName);
    Task<TUser?> FindByEmailAsync(string email);
    Task<bool>CreateUserAsync(TUser user, IEnumerable<string> roles);
    Task<bool>UpdateUserAsync(TUser user, IEnumerable<string> roles);
    Task<bool>DeleteUserAsync(TUser user, IEnumerable<string> roles);

    Task AddRoleInUser(int userId, string roleName);
    Task<bool> ValidatePasswordAsync(TUser user, string password);
}