using UserManagement.API.Entities.Users;

namespace UserManagement.API.Abstractions
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<bool> IsRegisteredAsync(string email);

        Task SaveChangesAsync();
    }
}