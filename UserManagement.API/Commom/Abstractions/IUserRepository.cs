using UserManagement.API.Features.Users.Entities;

namespace UserManagement.API.Commom.Abstractions
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<bool> IsRegisteredAsync(string email);

        Task SaveChangesAsync();
    }
}