using FluentResults;
using LibraryManagement.API.Request;
using LibraryManagement.Application.Commands;
using LibraryManagement.Application.Errors;
using LibraryManagement.Application.Response;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private IMemberCommandService _memberService;
        public MembersController(IMemberCommandService memberService)
        {
            _memberService = memberService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(Guid id)
        {
            var member = await _memberService.GetMemberAsync(id);
            if (member is null)
                return NotFound();

            return Ok(member);
        }

        [HttpPost()]
        public async Task<ActionResult<Member>> AddMember(CreateMemberRequest request)
        {

            MemberResponse response =  await _memberService.AddAsync(request.Name, request.Email);
            
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(Guid id)
        {
            Result result = await _memberService.DeleteAsync(id);
            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);
            else if(result.HasError<DeleteNotPermittenHindiPaNagsasauli>(out var deleteErros))
                return BadRequest(deleteErros.FirstOrDefault()?.Message);

            return NoContent();
        }
    }
}
