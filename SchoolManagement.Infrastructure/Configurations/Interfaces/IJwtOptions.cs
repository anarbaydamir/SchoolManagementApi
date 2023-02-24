namespace SchoolManagement.Infrastructure.Configurations.Interfaces
{
    public interface IJwtOptions
    {
        string Issuer { get; }
        string Auidence { get; }
        string SecretKey { get; }
        int JwtTokenValidityInMinutes { get; }
        int JwtRefreshTokenValidityInDays { get; }
    }
}
