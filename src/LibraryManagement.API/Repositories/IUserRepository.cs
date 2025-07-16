using LibraryManagement.API.Data.Models;

namespace LibraryManagement.API.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetUsersAsync();
        Task SaveChangeAsync();
    }
}
