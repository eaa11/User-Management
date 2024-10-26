using UserManagement.API.Abstractions;

namespace UserManagement.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUsersDbContext _context;

        public IUserRepository Users { get; }

        public UnitOfWork(IUsersDbContext context, IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}