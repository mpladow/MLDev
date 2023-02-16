using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface IJWTokenService
    {
        JwtSecurityToken GetJwtSecurityToken(List<Claim> userClaims);
    }
}
