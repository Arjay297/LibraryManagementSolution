

using LibraryManagement.Domain.Exceptions;
using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Domain.Entities
{
    public class Book
    {
        public BookId Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
        public List<BorrowingRecord> BorrowingHistory { get; set; }

        public void MarkAsBorrowed()
        {
            if(IsBorrowed)
            {
                throw new BookAlreadyBorrowedException("This book is already borrowed.");
            }
            IsBorrowed = true;
        }

        public void MarkAsReturned()
        {
            if(!IsBorrowed)
            {
                throw new BookAlreadyReturnedException("This book is not borrowed.");
            }
            IsBorrowed = false;
        }
    }
}
