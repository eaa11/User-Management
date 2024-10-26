namespace UserManagement.API.Features.Users.Resquests
{
    public record RegisterUserRequest
        (
            string Name,
            string Email,
            string Password,
            List<RegisterPhoneRequest> Phones
        );
}