using Identity.Application.Response;

namespace Identity.Application.Commands
{
    public interface IAuthenticationCommands
    {
        Task<AuthenticationResponse> RegisterAsync(string name, string email, string password);
        Task<AuthenticationResponse> Login(string email, string password);
    }
}
