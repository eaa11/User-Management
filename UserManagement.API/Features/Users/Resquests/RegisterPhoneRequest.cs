namespace UserManagement.API.Features.Users.Resquests
{
    public record RegisterPhoneRequest
    (
        string Number,
        string CityCode,
        string CountryCode
    );
}