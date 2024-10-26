using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserManagement.API.Features.Users.Entities;

namespace UserManagement.API.Infrastructure.Data
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}