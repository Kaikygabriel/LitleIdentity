using LittleIdentity.Abstractions.Exceptions;
using LittleIdentity.Abstractions.ObjectValue;

namespace LitleIdentity.Test.Abstraction.Entities;

public class IdentityUserTest
{
    private const string NameInvalid = "";
    private const string? NameNull =null;
    private const string NameValid = "Teste";
    
    private const string PasswordInvalid= "";
    private const string? PasswordNull =null;
    private const string PasswordValid = "Teste123";

    private readonly Email EmailValid = new ("teste@gmail.com");

    [Fact]
    public void CreateIdentityUser_PasswordInvalid_NameInvalid_Return_UserException()
    {
        Assert.Throws<UserException>(() =>
            new LittleIdentity.Abstractions.Entities.IdentityUser(NameInvalid, PasswordInvalid, EmailValid));
    }
    [Fact]
    public void CreateIdentityUser_PasswordNull_NameNull_Return_UserException()
    {
        Assert.Throws<UserException>(() =>
            new LittleIdentity.Abstractions.Entities.IdentityUser(NameNull, PasswordNull, EmailValid));
    }
    [Fact]
    public void CreateIdentityUser_PasswordValid_NameValid_Return_Ok()
    { 
        var user = new LittleIdentity.Abstractions.Entities.IdentityUser(NameValid, PasswordValid, EmailValid);
        Assert.Equal(user.Name,NameValid);        
        Assert.Equal(user.Password,PasswordValid);
    }
}