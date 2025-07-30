using AutoMapper;
using LibraryManagement.Application.Queries;
using LibraryManagement.Application.Response;
using LibraryManagement.Domain.ValueObjects;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Services
{
    public class BorrowingQueryService : IBorrowingQueryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BorrowingQueryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BorrowingRecordResponse>> GetBorrowingRecords(Guid memberId)
        {
            var history = await _context.BorrowingRecords.Where(b => b.BorrowerId == new MemberId(memberId))
                .Include(b => b.Borrower)
                .Include(b => b.Book)
                .ToListAsync();

            var response = _mapper.Map<List<BorrowingRecordResponse>>(history);
            return response;
        }
    }
}
