namespace UserManagement.API.Entities.Users;

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