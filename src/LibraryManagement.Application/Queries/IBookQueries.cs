using LibraryManagement.Application.Response;

namespace LibraryManagement.Application.Queries
{
    public interface IBookQueries
    {
        Task<BookResponse?> GetBookByIdAsync(Guid id);
        Task<List<BookResponse>> GetBooksAsync();   
    }
}
