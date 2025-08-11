using Borrowing.Domain.Exceptions;
using Borrowing.Domain.ValueObjects;

namespace Borrowing.Domain.Entities
{

    public class Member
    {
        public MemberId Id { get; private set; } = null!;
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int MaxBook { get; private set; }
        public int BorrowedBookCount { get; private set; }
        public List<BorrowingRecord> BorrowingHistory { get; set; } = [];

        private Member(MemberId id, string name, string email, int maxBook, int borrowedBookCount)
        {
            Id = id;
            Name = name;
            Email = email;
            MaxBook = maxBook;
            BorrowedBookCount = borrowedBookCount;
        }

        public static Member Create(string name, string email)
        {
            var member = new Member(new MemberId(Guid.NewGuid()), name, email, 3, 0);
            return member;
        }


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
