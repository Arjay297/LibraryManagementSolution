using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(BookId bookId);
        Task AddAsync(Book book);
       
    }
}
