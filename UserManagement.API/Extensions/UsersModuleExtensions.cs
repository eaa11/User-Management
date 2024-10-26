using Microsoft.EntityFrameworkCore;
using UserManagement.API.Abstractions;
using UserManagement.API.Data;
using UserManagement.API.Services;

namespace UserManagement.API.Extensions
{
    public static class UsersModuleExtensions
    {
        public static IServiceCollection AddUserModuleServices(
            this IServiceCollection services,
            ConfigurationManager config)
        {
            string? connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<IUsersDbContext, UsersDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}