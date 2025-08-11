using Borrowing.Application.Commands;
using Borrowing.Application.Errors;
using Borrowing.Domain.Entities;
using Borrowing.Domain.Exceptions;
using Borrowing.Domain.Repositories;
using Borrowing.Domain.Services;
using Borrowing.Domain.ValueObjects;
using FluentResults;

namespace Borrowing.Application.CommandHandler
{
    public class BorrowingCommands : IBorrowingCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public BorrowingCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> BorrowAsync(Guid bookId, Guid memberId, CancellationToken cancellationToken)
        {
            try
            {
                Book? book = await _unitOfWork.Books.GetByIdAsync(new BookId(bookId));
                if (book is null)
                    return Result.Fail(new EntityNotFoundError($"Book not found {bookId}"));
                Member? member = await _unitOfWork.Members.GetByIdAsync(new MemberId(memberId));
                if (member is null)
                    return Result.Fail(new EntityNotFoundError($"Member not found {memberId}"));

                var borrowingService = new BorrowingService();
                BorrowingRecord record = borrowingService.BorrowBook(member, book);

                await _unitOfWork.BorrowingRecords.AddAsync(record);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Ok();
            }
            catch (BookAlreadyBorrowedException)
            {
                return Result.Fail(new BookAlreadyBorrowedError());
            } 
            catch (MemberCantBorrowedMoreThanAllowedException ex)
            {
                return Result.Fail(new MemberCantBorrowedMoreThanAllowedError(ex.Message));
            }
            
        }


        public async Task<Result> ReturnAsync(Guid bookId, Guid memberId, CancellationToken cancellationToken)
        {
            try
            {
                BorrowingRecord? record = await _unitOfWork
                    .BorrowingRecords
                    .GetByMemberAndBookIdAsync(new BookId(bookId), new MemberId(memberId));

                if(record is null)
                    return Result.Fail(new EntityNotFoundError($"Borrowing record not found for book {bookId} and member {memberId}"));

                var borrowingService = new BorrowingService();
                borrowingService.ProcessReturn(record);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Ok();
            }
            catch (BookAlreadyReturnedException)
            {
                return Result.Fail(new BookAlreadyBorrowedError());
            }     
        }
    }
}
