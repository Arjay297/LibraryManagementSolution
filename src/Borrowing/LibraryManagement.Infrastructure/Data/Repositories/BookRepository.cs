using Borrowing.Domain.Entities;
using Borrowing.Domain.Repositories;
using Borrowing.Domain.ValueObjects;
using Borrowing.Infrastructure.Data;

namespace Borrowing.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BorrowingDbContext _context;

        public BookRepository(BorrowingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<Book?> GetByIdAsync(BookId bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }
    }
}
