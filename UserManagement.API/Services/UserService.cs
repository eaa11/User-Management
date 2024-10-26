using Microsoft.Extensions.Options;
using UserManagement.API.Abstractions;
using UserManagement.API.Dto;
using UserManagement.API.Entities.Users;
using UserManagement.API.Resquests;

namespace UserManagement.API.Services
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

                var user = User.Create(
                    new Name(request.Name),
                    new Email(request.Email),
                    new Password(request.Password, _passwordSettings.Value.RegexPattern)
                  );

                foreach (var phoneRequest in request.Phones)
                {
                    var phone = new Phone(phoneRequest.Number,
                                          phoneRequest.CityCode,
                                          phoneRequest.CountryCode);
                    user.AddPhone(phone);
                }

                await _userRepository.AddAsync(user);

                await _userRepository.SaveChangesAsync();

                var response = new RegistrationDto(
                    user.Id,
                    user.Created.Value,
                    user.Modified.Value,
                    user.LastLogin.Value,
                    user.Token.ToString(),
                    user.IsActive
                );
                return Result<RegistrationDto>.Success(response);
            }
            catch (ValidationException ex)
            {
                return Result<RegistrationDto>.Failure(ex.Message);
            }
        }
    }
}