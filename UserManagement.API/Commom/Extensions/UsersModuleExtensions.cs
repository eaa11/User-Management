using Microsoft.EntityFrameworkCore;
using UserManagement.API.Commom.Abstractions;
using UserManagement.API.Config;
using UserManagement.API.Features.Users.Services;
using UserManagement.API.Infrastructure.Data;
using UserManagement.API.Infrastructure.Repositories;

namespace UserManagement.API.Commom.Extensions
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