using FluentResults;

namespace Borrowing.Application.Commands
{
    public interface IBorrowingCommands
    {
        Task<Result> BorrowAsync(Guid bookId, Guid memberId, CancellationToken cancellationToken);
        Task<Result> ReturnAsync(Guid bookId, Guid memberId, CancellationToken cancellationToken);
    }
}
