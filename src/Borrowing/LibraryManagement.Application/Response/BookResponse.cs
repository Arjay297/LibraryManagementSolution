namespace Borrowing.Application.Response
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsBorrowed { get; set; }
        public List<BookBorrowingRecordResponse> BorrowingHistory { get; set; } = [];
    }
}
