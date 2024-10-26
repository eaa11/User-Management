using Microsoft.EntityFrameworkCore;
using UserManagement.API.Commom.Abstractions;
using UserManagement.API.Features.Users.Entities;
using UserManagement.API.Infrastructure.Data;

namespace UserManagement.API.Infrastructure.Repositories
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