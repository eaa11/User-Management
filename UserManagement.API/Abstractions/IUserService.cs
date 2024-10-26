using UserManagement.API.Dto;
using UserManagement.API.Resquests;

namespace UserManagement.API.Abstractions
{
    public interface IUserService
    {
        Task<Result<RegistrationResponseDto>> RegisterAsync(UserCreateRequest request);
    }
}