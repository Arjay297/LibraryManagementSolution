namespace Borrowing.Domain.Exceptions
{
    [Serializable]
    public class BookAlreadyReturnedException(string message) : DomainException(message)
    {
      

       
    }
}