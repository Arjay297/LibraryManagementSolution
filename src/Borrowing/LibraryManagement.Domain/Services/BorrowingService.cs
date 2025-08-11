using Borrowing.Domain.Entities;

namespace Borrowing.Domain.Services
{
    public class BorrowingService
    {
        public BorrowingRecord BorrowBook(Member member, Book book)
        {
            member.IncreaseBorrowedBookCount();
            book.MarkAsBorrowed();
            return BorrowingRecord.Create(
                member.Id,
                book.Id,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(14));
        }

        public void ProcessReturn(BorrowingRecord record)
        {
            record.Process();
        }
    }
}
