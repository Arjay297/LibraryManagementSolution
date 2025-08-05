

using LibraryManagement.Domain.Exceptions;
using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Domain.Entities
{
    public class Book
    {
        public BookId Id { get; private set; } = null!;
        public string Title { get; private set; } = null!;
        public bool IsBorrowed { get; private set; }
        public List<BorrowingRecord> BorrowingHistory { get; set; } = [];


        protected Book()
        {
            
        }

        public static Book Create(string title)
        {  
            return new Book
            {
                Id = new BookId(Guid.NewGuid()),
                Title = title,
                IsBorrowed = false
            };
        }

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
