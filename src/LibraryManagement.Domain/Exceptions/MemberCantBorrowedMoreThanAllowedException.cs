namespace LibraryManagement.Domain.Exceptions
{
    public class MemberCantBorrowedMoreThanAllowedException(string message) : DomainException(message)
    {
    }
}
