using UserManagement.API.Commom;

namespace UserManagement.API.Features.Users.Entities;

public record Phone
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Number { get; private set; }
    public string CityCode { get; private set; }
    public string CountryCode { get; private set; }

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