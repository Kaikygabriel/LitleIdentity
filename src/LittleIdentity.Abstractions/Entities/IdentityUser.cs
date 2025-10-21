using System.ComponentModel.DataAnnotations;
using LittleIdentity.Abstractions.Exceptions;
using LittleIdentity.Abstractions.ObjectValue;

namespace LittleIdentity.Abstractions.Entities;

public class IdentityUser
{
    public IdentityUser(string name, string password, Email email)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            throw new UserException("Name or Password is null or white space!");
        Name = name;
        Password = password;
        Email = email;
    }

    [Required]
    [StringLength(120)] 
    public string Name { get; set; } 
    [Required]
    [StringLength(100,MinimumLength = 4)]
    public string Password { get; set; }

    public Email Email { get; set; }
    [Required]
    [Key]
    public int Id { get; set; }

    public List<IdentityRole> Roles { get; private set; } = new();
    
    public void SetRole(IdentityRole role)
        =>  Roles.Add(role);

    public IEnumerable<IdentityRole>GetRoles()
        => Roles;
}