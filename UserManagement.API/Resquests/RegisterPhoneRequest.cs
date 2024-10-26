namespace UserManagement.API.Resquests
{
    public record RegisterPhoneRequest
    (
        string Number,
        string CityCode,
        string CountryCode
    );
}