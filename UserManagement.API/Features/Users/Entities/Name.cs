using UserManagement.API.Commom;

namespace UserManagement.API.Features.Users.Entities;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException("Name cannot be empty.");
        }
        Value = value;
    }
    public override string ToString() => Value;
}