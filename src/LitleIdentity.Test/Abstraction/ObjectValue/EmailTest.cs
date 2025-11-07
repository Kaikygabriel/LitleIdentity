using LittleIdentity.Abstractions.Exceptions;
using LittleIdentity.Abstractions.ObjectValue;

namespace LitleIdentity.Test.Abstraction.ObjectValue;

public class EmailTest
{
    private const string AddressValid = "teste@gmail.com";
    private const string? AddressNull = null;
    private const string AddressEmpty = "";
    
    
    [Fact]
    public void CreateEmail_AddressNull_Return_EmailException()
    {
        Assert.Throws<EmailException>(() =>
            new Email(AddressNull));
    }
    [Fact]
    public void CreateEmail_AddressEmpty_Return_EmailException()
    {
        Assert.Throws<EmailException>(() =>
            new Email(AddressEmpty));
    }
    [Fact]
    public void CreateEmail_AddressValid_Return_Ok()
    {
        var email =new Email(AddressValid);
        Assert.Equal(email.Address,AddressValid);
    }
}