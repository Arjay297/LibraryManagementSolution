using Borrowing.Application.Response;
using FluentResults;

namespace Borrowing.Application.Commands
{
    public interface IMemberCommands
    {
        Task<MemberResponse?> GetMemberAsync(Guid id);
        Task AddAsync(string name, string email);

        Task<Result> DeleteAsync(Guid id);
    }
}
