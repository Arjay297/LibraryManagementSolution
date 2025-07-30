using LibraryManagement.API.Request;
using LibraryManagement.Application.Commands;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagement.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationCommandService _authenticationService;
        private readonly IBorrowingCommandService _borrowingCommandService;

        public AuthenticationController(IAuthenticationCommandService authenticationService,
            IBorrowingCommandService borrowingCommandService)
        {
            _authenticationService = authenticationService;
            _borrowingCommandService = borrowingCommandService;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            
            var response =
                await _authenticationService.RegisterAsync(request.Name, request.Email, request.Password);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authenticationService.Login(request.Email, request.Password);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
    }
}
