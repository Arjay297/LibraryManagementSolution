namespace LibraryManagement.Application.Response
{
    public class MemberResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }


    }
}
