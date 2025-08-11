using Borrowing.Application.Commands;
using Borrowing.Application.Queries;
using Borrowing.Application.Response;
using Borrowing.Controllers.Request;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Borrowing.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookCommands _commands;
        private readonly IBookQueries _queries;

        public BooksController(IBookCommands commands, IBookQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }


        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult<BookResponse>> GetBookById(Guid id)
        {
            BookResponse? book = await _queries.GetBookByIdAsync(id);
            if (book is null)
                return NotFound();
            return Ok(book);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            BookResponse book = await _commands.AddBookAsync(request.Title, HttpContext.RequestAborted);
            return CreatedAtRoute(nameof(GetBookById), new { book.Id}, book);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            Result result = await _commands.DeleteBookAsync(id, HttpContext.RequestAborted);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }


        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {
            List<BookResponse> books = await _queries.GetBooksAsync();
            return Ok(books);
        }
    }
}
