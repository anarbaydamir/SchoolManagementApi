using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        TokenModel AuthenticateUser(string email, string password);
        string RefreshToken(string refreshToken);

    }
}
