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
            services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            services.Configure<PasswordSettings>(config.GetSection("PasswordSettings"));
            return services;
        }
    }
}