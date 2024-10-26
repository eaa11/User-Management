namespace UserManagement.API.Features.Users.Dtos
{
    public record RegistrationDto
    (
        Guid Id,
        DateTime Created,
        DateTime Modified,
        DateTime LastLogin,
        string Token,
        bool IsActive
    );
}