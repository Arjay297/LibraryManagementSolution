namespace LibraryManagement.Application.Response
{
    public class MemberBorrowingRecordResponse
    {
        public Guid Id { get; private set; }
        public BorrowingRecordBookResponse Book { get; private set; } = null!;
        public DateTime DateBorrowed { get; private set; }
        public DateTime DateOverdue { get; private set; }
        public DateTime? DateReturned { get; private set; }
    }

    public class BorrowingRecordBookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
