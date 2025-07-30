

using LibraryManagement.Domain.Exceptions;
using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Domain.Entities
{

    public class Member
    {
        public MemberId Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int MaxBook { get; set; }
        public int BorrowedBookCount { get; set; }

        public void IncreaseBorrowedBookCount()
        {
            if (BorrowedBookCount >= MaxBook)
            {
                throw new MemberCantBorrowedMoreThanAllowedException($"Cant borrow more than {MaxBook}");
            }
            BorrowedBookCount++;
        }

        public void DecreaseBorrowedBookCount()
        {
            if (BorrowedBookCount <= 0)
            {
                throw new MemberCantReturnMoreThanBorrowedException("Member can't return more books than borrowed.");
            }
            BorrowedBookCount--;
        }   
    }
}
