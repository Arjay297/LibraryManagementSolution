namespace LibraryManagement.API.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
        public Guid? BorrowerId { get; set; }
        public Member? Borrower { get; set; }
    }
}
