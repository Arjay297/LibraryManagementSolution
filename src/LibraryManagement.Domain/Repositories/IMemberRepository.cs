using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Domain.Repositories
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);
        Task<Member?> GetByIdAsync(MemberId id);
        Task Delete(Member member);
    }
}
