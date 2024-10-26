using UserManagement.API.Abstractions;
using UserManagement.API.Dto;
using UserManagement.API.Entities.Users;
using UserManagement.API.Resquests;

namespace UserManagement.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<RegistrationResponseDto>> RegisterAsync(UserCreateRequest request)
        {
            var existingUser = await _unitOfWork.Users.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return Result<RegistrationResponseDto>.Failure("Email already exists.");
            }

            var user = User.Create(new Name(request.Name),
                                    new Email(request.Email),
                                    new Password(request.Password));

            foreach (var phoneRequest in request.Phones)
            {
                var phone = new Phone(phoneRequest.Number,
                                      phoneRequest.CityCode,
                                      phoneRequest.CountryCode);
                user.AddPhone(phone);
            }

            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.CommitAsync();

            var response = new RegistrationResponseDto(
                user.Id,
                user.Name.ToString(),
                user.Email.ToString(),
                user.Created.Value,
                user.Modified.Value,
                user.LastLogin.Value,
                user.Token.ToString(),
                user.IsActive
            );
            return Result<RegistrationResponseDto>.Success(response);
        }
    }
}