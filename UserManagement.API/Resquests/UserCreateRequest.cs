namespace UserManagement.API.Resquests
{
    public record UserCreateRequest
        (
            string Name,
            string Email,
            string Password,
            List<PhoneCreateRequest> Phones
        );
}