using UserManagement.API.Features.Users.Dtos;
using UserManagement.API.Features.Users.Resquests;

namespace UserManagement.API.Commom.Abstractions
{
    public interface IUserService
    {
        Task<Result<RegistrationDto>> RegisterAsync(RegisterUserRequest request);
    }
}