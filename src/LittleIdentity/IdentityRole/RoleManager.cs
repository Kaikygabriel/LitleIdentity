using LittleIdentity.Abstractions.Interfaces.IdentityRole;
using LittleIdentity.Abstractions.Interfaces.IdentityRole.Repositories;

namespace LitleIdentity.IdentityRole;

public class RoleManager : IManagerRole
{
    private readonly IRepositoryRole _repositoryRole;

    public RoleManager(IRepositoryRole repositoryRole)
    {
        _repositoryRole = repositoryRole;
    }

    public async Task<bool> CreateRoleAsync(LittleIdentity.Abstractions.ObjectValue.IdentityRole role)
    {
        try
        {
            await _repositoryRole.Create(role);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeleteRoleAsync(LittleIdentity.Abstractions.ObjectValue.IdentityRole role)
    {
        try
        {
            await _repositoryRole.Delete(role);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}