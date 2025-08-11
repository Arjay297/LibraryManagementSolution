namespace Borrowing.Application.Response
{
    public class MemberResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int BorrowedBookCount { get; set; }
        public List<MemberBorrowingRecordResponse> BorrowingHistory { get; set; } = [];
    }
}
