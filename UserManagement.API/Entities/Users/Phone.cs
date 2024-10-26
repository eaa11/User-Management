namespace UserManagement.API.Entities.Users;

public record Phone
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Number { get; }
    public string CityCode { get; }
    public string CountryCode { get; }

    public Phone(string number, string cityCode, string countryCode)
    {
        if (string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(cityCode) || string.IsNullOrWhiteSpace(countryCode))
        {
            throw new ValidationException("Phone data cannot be empty.");
        }

        Number = number;
        CityCode = cityCode;
        CountryCode = countryCode;
    }

    public override string ToString() => $"{CountryCode} {CityCode} {Number}";
}