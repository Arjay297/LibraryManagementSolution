using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(BookId bookId);
        void Delete(Book book);
        Task AddAsync(Book book);
       
    }
}
