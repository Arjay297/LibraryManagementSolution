using AutoMapper;
using AutoMapper.QueryableExtensions;
using Borrowing.Application.Queries;
using Borrowing.Application.Response;
using Borrowing.Domain.ValueObjects;
using Borrowing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Infrastructure.QueryHandlers
{
    public class BookQueries : IBookQueries
    {
        private readonly BorrowingDbContext _context;
        private readonly IMapper _mapper;

        public BookQueries(BorrowingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookResponse?> GetBookByIdAsync(Guid id)
        {
            var book = await _context.Books
                .Where(b => b.Id == new BookId(id))
                .FirstOrDefaultAsync();
            if (book is null)
                return null;
            return _mapper.Map<BookResponse>(book);    
        }

        public async Task<List<BookResponse>> GetBooksAsync()
        {

            return await _context.Books.ProjectTo<BookResponse>(_mapper.ConfigurationProvider).ToListAsync() ;
        }

    }
}
