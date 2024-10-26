namespace UserManagement.API.Resquests
{
    public record PhoneCreateRequest
    (
        string Number,
        string CityCode,
        string CountryCode
    );
}