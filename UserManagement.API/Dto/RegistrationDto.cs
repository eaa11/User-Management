namespace UserManagement.API.Dto
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