using LibraryManagement.API.Repositories;

namespace LibraryManagement.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IMemberRepository Members { get; }
        IBookRepository Books { get; }
        IBorrowingRecordRepository BorrowingRecords { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
