namespace LibraryManagement.Domain.Exceptions
{
    [Serializable]
    public class MemberCantReturnMoreThanBorrowedException : Exception
    {
        public MemberCantReturnMoreThanBorrowedException()
        {
        }

        public MemberCantReturnMoreThanBorrowedException(string? message) : base(message)
        {
        }

        public MemberCantReturnMoreThanBorrowedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}