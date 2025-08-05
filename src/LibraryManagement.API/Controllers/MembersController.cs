using LibraryManagement.Application.Commands;
using LibraryManagement.Application.Queries;
using LibraryManagement.Application.Response;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMemberQueries _queries;

        public MembersController(IMemberQueries queries)
        {
            _queries = queries;
        }


        [HttpGet("{id}", Name = "GetMember")]
        public async Task<ActionResult<MemberResponse>> GetMember(Guid id)
        {
            MemberResponse? member = await _queries.GetMemberByIdAsync(id);
            if (member is null)
                return NotFound();

            return Ok(member);
        }

        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            List<MemberResponse> members = await _queries.GetMembersAsync();
            return Ok(members);
        }
    }
}
