using LittleIdentity.Abstractions.Exceptions;

namespace LittleIdentity.Abstractions.ObjectValue;

public class IdentityRole
{
    public IdentityRole()
    {
        
    }
    public IdentityRole(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new RoleException("Title is null or white space!");
        Title = title;
    }

    public string Title { get; set; }
}