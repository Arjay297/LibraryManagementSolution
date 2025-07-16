using LibraryManagement.API.Dtos.Response;

namespace LibraryManagement.API.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> RegisterAsync(string name, string email, string password);
        Task<AuthenticationResponse> Login(string email, string password);
    }
}
