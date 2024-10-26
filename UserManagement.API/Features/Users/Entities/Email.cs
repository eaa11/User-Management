using System.Text.RegularExpressions;
using UserManagement.API.Commom;

namespace UserManagement.API.Features.Users.Entities;

public record Email
{
    public string Value { get; }

    public const string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public Email(string value)
    {
        if (!Regex.IsMatch(value, EMAIL_PATTERN))
        {
            throw new ValidationException("Invalid email format");
        }
        Value = value;
    }

    public override string ToString() => Value;
}