using AutoMapper;
using LibraryManagement.API.Data.Models;
using LibraryManagement.API.Dtos.Response;

namespace LibraryManagement.API.MappingProfile
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
