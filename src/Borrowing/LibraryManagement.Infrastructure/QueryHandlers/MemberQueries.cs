using AutoMapper;
using AutoMapper.QueryableExtensions;
using Borrowing.Application.Queries;
using Borrowing.Application.Response;
using Borrowing.Domain.ValueObjects;
using Borrowing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Infrastructure.QueryHandlers
{
    public class MemberQueries : IMemberQueries
    {
        private readonly BorrowingDbContext _context;
        private readonly IMapper _mapper;

        public MemberQueries(BorrowingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberResponse?> GetMemberByIdAsync(Guid id)
        {
            var member = await _context.Members
                .Where(m => m.Id == new MemberId(id))
                .FirstOrDefaultAsync();
            if (member is null)
                return null;

            return _mapper.Map<MemberResponse>(member);

        }

        public async Task<List<MemberResponse>> GetMembersAsync()
        {        
            return await _context.Members.ProjectTo<MemberResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
