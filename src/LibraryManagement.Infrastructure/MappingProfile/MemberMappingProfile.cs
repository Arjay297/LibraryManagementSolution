using AutoMapper;
using LibraryManagement.Application.Response;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Infrastructure.MappingProfile
{
    public class MemberMappingProfile : Profile
    {
        public MemberMappingProfile()
        {
            CreateMap<Member, MemberResponse>();

            //Source - Destination
            CreateMap<Book, BookResponse>();
        }
    }
}
