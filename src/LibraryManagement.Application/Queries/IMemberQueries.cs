using LibraryManagement.Application.Response;

namespace LibraryManagement.Application.Queries
{
    public interface IMemberQueries
    {
        Task<MemberResponse?> GetMemberByIdAsync(Guid id);
        Task<List<MemberResponse>> GetMembersAsync();
    }
}
