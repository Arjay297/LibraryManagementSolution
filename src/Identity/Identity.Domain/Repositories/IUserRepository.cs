using Identity.Domain.Entities;

namespace Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetUsersAsync();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
