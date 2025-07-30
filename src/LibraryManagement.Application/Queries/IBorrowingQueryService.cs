using LibraryManagement.Application.Response;

namespace LibraryManagement.Application.Queries
{
    public interface IBorrowingQueryService
    {
        Task<List<BorrowingRecordResponse>> GetBorrowingRecords(Guid memberId);
    }
}
