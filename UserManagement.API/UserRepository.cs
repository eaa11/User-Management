using Microsoft.EntityFrameworkCore;
using UserManagement.API.Abstractions;
using UserManagement.API.Data;
using UserManagement.API.Entities.Users;

namespace UserManagement.API
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> IsRegisteredAsync(string email)
        {
            return await _context.Users
                .AnyAsync(user => user.Email == new Email(email));
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}