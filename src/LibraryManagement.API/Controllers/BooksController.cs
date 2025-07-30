using LibraryManagement.API.Request;
using LibraryManagement.Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
       

        public BooksController()
        {
         

        }


        [HttpPost]
        [Authorize(Roles = "Librarian, Member")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {

            return Ok();
        }
    }
}
