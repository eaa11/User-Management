using FastEndpoints;
using UserManagement.API.Commom.Abstractions;
using UserManagement.API.Features.Users.Dtos;
using UserManagement.API.Features.Users.Resquests;

namespace UserManagement.API.Features.Users.Endpoints
{
    public class RegisterUserEndpoint(IUserService userService) :
        Endpoint<RegisterUserRequest, Result<RegistrationDto>>
    {
        private readonly IUserService _userService = userService;

        public override void Configure()
        {
            Post("api/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RegisterUserRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _userService.RegisterAsync(request);

            await SendAsync(result, result.StatusCode);
        }
    }
}