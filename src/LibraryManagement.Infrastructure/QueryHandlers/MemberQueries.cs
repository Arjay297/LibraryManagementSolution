using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagement.Application.Queries;
using LibraryManagement.Application.Response;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.ValueObjects;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.QueryHandlers
{
    public class MemberQueries : IMemberQueries
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MemberQueries(ApplicationDbContext context, IMapper mapper)
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
