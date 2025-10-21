using System.ComponentModel.DataAnnotations;
using LittleIdentity.Abstractions.Exceptions;

namespace LittleIdentity.Abstractions.ObjectValue;

public class Email
{
    public Email()
    {
        
    }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !address.Contains('@'))
            throw new EmailException("Email is null or invalid");
        Address = address;
    }
    [EmailAddress]
    public string Address { get; set; }
}