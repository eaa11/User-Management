namespace UserManagement.API.Dto
{
    public record RegistrationResponseDto
    (
        Guid Id,
        string Name,
        string Email,
        DateTime Created,
        DateTime Modified,
        DateTime LastLogin,
        string Token,
        bool IsActive
    );
}