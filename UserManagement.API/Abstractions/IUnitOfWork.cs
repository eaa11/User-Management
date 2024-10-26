namespace UserManagement.API.Abstractions
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task<int> CommitAsync();
    }
}