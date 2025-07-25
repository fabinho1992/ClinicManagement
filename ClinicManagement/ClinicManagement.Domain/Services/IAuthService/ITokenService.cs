using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ClinicManagement.Domain.Services.IAuthService
{
    public interface ITokenService
    {
        JwtSecurityToken GenerationToken(IEnumerable<Claim> claims, IConfiguration _config);
    }
}
