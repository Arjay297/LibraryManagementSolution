using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagement.API.Configurations;
using LibraryManagement.API.Data;
using LibraryManagement.API.Dtos.Request;
using LibraryManagement.API.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryManagement.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly JwtSettings settings;

        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }



        [HttpPost]
        [Authorize(Roles = "Librarian, Member")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new Data.Models.Book
            {
                Title = request.Title
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {


            List<BookResponse> books = await context.Books
                .ProjectTo<BookResponse>(mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(books);
        }
    }
}
