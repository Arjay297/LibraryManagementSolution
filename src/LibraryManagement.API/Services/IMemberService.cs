using FluentResults;
using LibraryManagement.API.Dtos.Response;

namespace LibraryManagement.API.Services
{
    public interface IMemberService
    {
        Task<MemberResponse?> GetMemberAsync(Guid id);
        Task<MemberResponse> AddAsync(string name, string email);

        Task<Result> DeleteAsync(Guid id);
    }
}
