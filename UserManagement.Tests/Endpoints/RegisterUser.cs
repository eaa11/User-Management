using Moq;
using System.Net.Http.Json;
using UserManagement.API.Commom.Abstractions;
using UserManagement.API.Features.Users.Dtos;
using UserManagement.API.Features.Users.Resquests;

namespace UserManagement.Tests.Endpoints
{
    public class RegisterUser : IClassFixture<Fixture>
    {
        private readonly Fixture _fixture;

        public RegisterUser(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task RegisterUserAsync()
        {
            var listOfPhone = new List<RegisterPhoneRequest>
        {
            new RegisterPhoneRequest("2311122", "809", "1")
        };

            var registerRequest = new RegisterUserRequest(
                "Alejandra",
                "alejandraadames9@gmail.com",
                "A@9a",
                listOfPhone
            );

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.IsRegisteredAsync(It.IsAny<string>())).ReturnsAsync(false); // Adjust as needed for test

            var response = await _fixture.Client.PostAsJsonAsync("/users", registerRequest);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Result<RegistrationDto>>();

            Assert.NotNull(result);

            var registrationDto = result.Value;
            Assert.NotNull(registrationDto);
            Assert.True(registrationDto.IsActive);
            Assert.NotEqual(Guid.Empty, registrationDto.Id);
        }
    }
}