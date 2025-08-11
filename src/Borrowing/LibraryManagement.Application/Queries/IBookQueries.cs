using Borrowing.Application.Response;

namespace Borrowing.Application.Queries
{
    public interface IBookQueries
    {
        Task<BookResponse?> GetBookByIdAsync(Guid id);
        Task<List<BookResponse>> GetBooksAsync();   
    }
}
