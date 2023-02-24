using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Models;
using System.Security.Claims;

namespace SchoolManagement.Infrastructure.Authentication.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserClaimsModel userModel);
        RefreshToken GenerateRefreshToken();
    }
}
