using Borrowing.Domain.Entities;
using Borrowing.Domain.ValueObjects;

namespace Borrowing.Domain.Repositories
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);
        Task<Member?> GetByIdAsync(MemberId id);
        Task Delete(Member member);
    }
}
