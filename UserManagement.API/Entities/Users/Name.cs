namespace UserManagement.API.Entities.Users;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Name cannot be empty.");
        }
        Value = value;
    }
}