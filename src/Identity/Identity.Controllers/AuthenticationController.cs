using Identity.Application.Commands;
using Identity.Controllers.Request;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationCommands _authenticationService;


        public AuthenticationController(IAuthenticationCommands authenticationService)
        {
            _authenticationService = authenticationService;

            
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
