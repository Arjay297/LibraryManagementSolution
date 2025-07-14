namespace LibraryManagement.API.Dtos.Response
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public MemberResponse Borrower { get; set; }
    }
}
