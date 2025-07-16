using LibraryManagement.API.Data.Models;

namespace LibraryManagement.API.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
