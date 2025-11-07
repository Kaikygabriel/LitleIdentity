using LittleIdentity.Abstractions.Exceptions;

namespace LitleIdentity.Test.Abstraction.ObjectValue;

public class IdentityRoleTest
{
    private const string TitleValid = "Admin";
    private const string? TitleNull = null;
    private const string TitleEmpty = "";
    
    [Fact]
    public void CreateRole_TitleNull_Return_RoleException()
    {
        Assert.Throws<RoleException>(() =>
            new LittleIdentity.Abstractions.ObjectValue.IdentityRole(TitleNull));
    }
    [Fact]
    public void CreateRole_TitleEmpty_Return_RoleException()
    {
        Assert.Throws<RoleException>(() =>
            new LittleIdentity.Abstractions.ObjectValue.IdentityRole(TitleEmpty));
    }
    [Fact]
    public void CreateRole_TitleValid_Return_Ok()
    {
        var role =new LittleIdentity.Abstractions.ObjectValue.IdentityRole(TitleValid);
        Assert.Equal(role.Title,TitleValid);
    }
}