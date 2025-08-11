using AutoMapper;
using Borrowing.Application.Commands;
using Borrowing.Application.Errors;
using Borrowing.Application.Response;
using Borrowing.Domain.Entities;
using Borrowing.Domain.Repositories;
using Borrowing.Domain.ValueObjects;
using FluentResults;

namespace Borrowing.Application.CommandHandler
{
    public class BookCommands : IBookCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookResponse> AddBookAsync(string bookName, CancellationToken cancellationToken)
        {
            Book book = Book.Create(bookName);
            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BookResponse>(book);
        }

        public async Task<Result> DeleteBookAsync(Guid id, CancellationToken cancellationToken)
        {
            Book? book = await _unitOfWork.Books.GetByIdAsync(new BookId(id));
            if (book is null)
                return Result.Fail(new EntityNotFoundError($"Book with id = {id} not found"));
            _unitOfWork.Books.Delete(book);
            await _unitOfWork.SaveChangesAsync(cancellationToken);  
            return Result.Ok();
        }
    }
}
