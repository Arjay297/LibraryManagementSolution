using Borrowing.Application.Response;
using FluentResults;

namespace Borrowing.Application.Commands
{
    public interface IBookCommands
    {
        Task<BookResponse> AddBookAsync(string bookName, CancellationToken cancellationToken);
        Task<Result> DeleteBookAsync(Guid id, CancellationToken cancellationToken);
    }
}
