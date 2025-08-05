using FluentResults;
using LibraryManagement.Application.Response;

namespace LibraryManagement.Application.Commands
{
    public interface IBookCommands
    {
        Task<BookResponse> AddBookAsync(string bookName, CancellationToken cancellationToken);
        Task<Result> DeleteBookAsync(Guid id, CancellationToken cancellationToken);
    }
}
