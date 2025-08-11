using AutoMapper;
using Borrowing.Application.Response;
using Borrowing.Domain.Entities;

namespace Borrowing.Infrastructure.MappingProfile
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            //Mapping for members
            CreateMap<Member, MemberResponse>()
                .ForMember(m => m.Id, options => options.MapFrom(m => m.Id.Value));

            //Mapping for books
            CreateMap<Book, BookResponse>()
                .ForMember(b => b.Id, options => options.MapFrom(b => b.Id.Value));
            

            //Mapping for Book borrowing History
            CreateMap<BorrowingRecord, BookBorrowingRecordResponse>()
                .ForMember(b => b.Id, options => options.MapFrom(b => b.Id.Value));
            CreateMap<Member, BookBorrowerResponse>()
                .ForMember(m => m.Id, options => options.MapFrom(m => m.Id.Value));

            //Mapping for Member borrowing History
            CreateMap<BorrowingRecord, MemberBorrowingRecordResponse>()
                .ForMember(b => b.Id, options => options.MapFrom(b => b.Id.Value));
            CreateMap<Book, BorrowingRecordBookResponse>()
              .ForMember(m => m.Id, options => options.MapFrom(m => m.Id.Value));

        }
    }
}
