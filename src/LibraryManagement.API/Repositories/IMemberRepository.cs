using FluentResults;
using LibraryManagement.API.Data.Models;

namespace LibraryManagement.API.Repositories
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);
        Task<Member?> GetByIdAsync(Guid id);
        Task Delete(Member member);
    }
}
