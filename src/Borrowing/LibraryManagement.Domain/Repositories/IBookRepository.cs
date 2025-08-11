using Borrowing.Domain.Entities;
using Borrowing.Domain.ValueObjects;

namespace Borrowing.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(BookId bookId);
        void Delete(Book book);
        Task AddAsync(Book book);
       
    }
}
