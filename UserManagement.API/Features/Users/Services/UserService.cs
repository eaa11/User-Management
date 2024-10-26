using Microsoft.Extensions.Options;
using UserManagement.API.Commom;
using UserManagement.API.Commom.Abstractions;
using UserManagement.API.Config;
using UserManagement.API.Features.Users.Dtos;
using UserManagement.API.Features.Users.Entities;
using UserManagement.API.Features.Users.Resquests;

namespace UserManagement.API.Features.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IOptions<PasswordSettings> _passwordSettings;

        public UserService(
            IUserRepository userRepository,
            IOptions<PasswordSettings> passwordSettings)
        {
            _userRepository = userRepository;
            _passwordSettings = passwordSettings;
        }

        public async Task<Result<RegistrationDto>> RegisterAsync(RegisterUserRequest request)
        {
            try
            {
                var isRegistered = await _userRepository.IsRegisteredAsync(request.Email);

                if (isRegistered)
                {
                    return Result<RegistrationDto>.Failure("Email already in use.");
                }

                var user = CreateUser(request);

                AddPhonesToUser(user, request.Phones);

                await SaveUserAsync(user);

                var response = RegistrationResponse(user);

                return Result<RegistrationDto>.Success(response);
            }
            catch (ValidationException ex)
            {
                return Result<RegistrationDto>.Failure(ex.Message);
            }
        }

        private User CreateUser(RegisterUserRequest request)
        {
            return User.Create(
                new Name(request.Name),
                new Email(request.Email),
                new Password(request.Password, _passwordSettings.Value.RegexPattern)
            );
        }

        private void AddPhonesToUser(User user, IEnumerable<RegisterPhoneRequest> phoneRequests)
        {
            foreach (var phoneRequest in phoneRequests)
            {
                var phone = new Phone(
                    phoneRequest.Number,
                    phoneRequest.CityCode,
                    phoneRequest.CountryCode
                );
                user.AddPhone(phone);
            }
        }

        private async Task SaveUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        private RegistrationDto RegistrationResponse(User user)
        {
            return new RegistrationDto(
                    user.Id,
                    user.Created.Value,
                    user.Modified.Value,
                    user.LastLogin.Value,
                    user.Token.ToString(),
                    user.IsActive
                );
        }
    }
}