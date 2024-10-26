using Microsoft.EntityFrameworkCore;
using UserManagement.API.Abstractions;
using UserManagement.API.Entities.Users;

namespace UserManagement.API
{
    public class UserRepository : IUserRepository
    {
        private readonly IUsersDbContext _context;

        public UserRepository(IUsersDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
        }
    }
}