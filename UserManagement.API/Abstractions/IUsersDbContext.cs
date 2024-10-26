using Microsoft.EntityFrameworkCore;
using UserManagement.API.Entities.Users;

namespace UserManagement.API.Abstractions
{
    public interface IUsersDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Phone> Phones { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}