using FastEndpoints;
using UserManagement.API.Abstractions;
using UserManagement.API.Dto;
using UserManagement.API.Resquests;

namespace UserManagement.API.Endpoints
{
    public class RegisterUserEndpoint(IUserService userService) :
        Endpoint<RegisterUserRequest, Result<RegistrationDto>>
    {
        private readonly IUserService _userService = userService;

        public override void Configure()
        {
            Post("/users");
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