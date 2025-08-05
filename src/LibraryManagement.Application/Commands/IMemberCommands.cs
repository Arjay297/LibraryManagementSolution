using FluentResults;
using LibraryManagement.Application.Response;

namespace LibraryManagement.Application.Commands
{
    public interface IMemberCommands
    {
        Task<MemberResponse?> GetMemberAsync(Guid id);
        Task<MemberResponse> AddAsync(string name, string email);

        Task<Result> DeleteAsync(Guid id);
    }
}
