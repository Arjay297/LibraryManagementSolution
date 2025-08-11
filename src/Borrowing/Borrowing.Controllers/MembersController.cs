using Borrowing.Application.Queries;
using Borrowing.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Borrowing.Controllers
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
        public async Task<ActionResult<List<MemberResponse>>> GetMembers()
        {
            List<MemberResponse> members = await _queries.GetMembersAsync();
            return Ok(members);
        }
    }
}
