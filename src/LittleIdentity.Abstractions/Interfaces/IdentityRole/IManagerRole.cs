namespace LittleIdentity.Abstractions.Interfaces.IdentityRole;

public interface IManagerRole
{
    Task<bool> CreateRoleAsync(LittleIdentity.Abstractions.ObjectValue.IdentityRole role);
    Task<bool> DeleteRoleAsync(LittleIdentity.Abstractions.ObjectValue.IdentityRole role);
}