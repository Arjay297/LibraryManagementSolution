using LibraryManagement.API.Data;
using LibraryManagement.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.API.Repositories
{

    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
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

        public async Task<Member?> GetByIdAsync(Guid id)
        {
            return await _context.Members.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
