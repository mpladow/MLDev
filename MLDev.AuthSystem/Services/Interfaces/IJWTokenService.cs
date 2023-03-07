using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MLDev.AuthSystem.Services.Interfaces
{
    public interface IJWTokenService
    {
        JwtSecurityToken GetJwtSecurityToken(List<Claim> userClaims);
    }
}
