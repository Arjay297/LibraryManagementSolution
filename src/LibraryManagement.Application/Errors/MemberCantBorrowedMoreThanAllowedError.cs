using FluentResults;

namespace LibraryManagement.Application.Errors
{
    public class MemberCantBorrowedMoreThanAllowedError(string message) : Error(message)
    {
    }
}
