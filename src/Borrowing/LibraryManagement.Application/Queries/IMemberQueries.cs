using Borrowing.Application.Response;

namespace Borrowing.Application.Queries
{
    public interface IMemberQueries
    {
        Task<MemberResponse?> GetMemberByIdAsync(Guid id);
        Task<List<MemberResponse>> GetMembersAsync();
    }
}
