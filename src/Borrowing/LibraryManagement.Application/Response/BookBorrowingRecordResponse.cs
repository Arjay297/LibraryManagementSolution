namespace Borrowing.Application.Response
{
    public class BookBorrowingRecordResponse
    {
        public Guid Id { get; set; }
        public BookBorrowerResponse Borrower { get; set; } = null!;
        public DateTime DateBorrowed { get; set; }
        public DateTime DateOverdue { get; set; }
        public DateTime? DateReturned { get; set; }
    }

    public class BookBorrowerResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
