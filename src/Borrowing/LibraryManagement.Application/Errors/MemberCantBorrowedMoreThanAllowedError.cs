using FluentResults;

namespace Borrowing.Application.Errors
{
    public class MemberCantBorrowedMoreThanAllowedError(string message) : Error(message)
    {
    }
}
