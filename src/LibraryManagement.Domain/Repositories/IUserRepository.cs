using LibraryManagement.Domain.Entities;

namespace LibraryManagement.API.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetUsersAsync();
    }
}
