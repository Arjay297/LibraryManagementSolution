namespace Borrowing.Domain.Exceptions
{
    public class BookAlreadyBorrowedException(string message) : DomainException(message)
    {
    }
}
