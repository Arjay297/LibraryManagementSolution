using Borrowing.Domain.Entities;
using Borrowing.Domain.Repositories;
using Borrowing.Domain.ValueObjects;
using Borrowing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Infrastructure.Data.Repositories
{

    public class MemberRepository : IMemberRepository
    {
        private readonly BorrowingDbContext _context;

        public MemberRepository(BorrowingDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Member member)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }

        public async Task<Member?> GetByIdAsync(MemberId id)
        {
            return await _context.Members.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
