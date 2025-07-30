using LibraryManagement.Application.Response;

namespace LibraryManagement.Application.Commands
{
    public interface IAuthenticationCommandService
    {
        Task<AuthenticationResponse> RegisterAsync(string name, string email, string password);
        Task<AuthenticationResponse> Login(string email, string password);
    }
}
