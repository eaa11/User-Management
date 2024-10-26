using System.Text.RegularExpressions;

namespace UserManagement.API.Entities.Users;

public record Email
{
    public string Value { get; }

    public const string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@dominio\.cl$";

    public Email(string value)
    {
        if (!Regex.IsMatch(value, EMAIL_PATTERN))
        {
            throw new ArgumentException("Invalid email format");
        }
        Value = value;
    }

    public override string ToString() => Value;
}