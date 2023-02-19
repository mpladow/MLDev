using Microsoft.IdentityModel.Tokens;
using MLDev.LOTOW.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MLDev.LOTOW.Services
{
    public class JwTokenService : IJWTokenService
    {
        private readonly IConfiguration _configuration;
        public JwTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken GetJwtSecurityToken(List<Claim> userClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuthentication:AccessTokenSecret"]));
            var expiryInMinutes = Convert.ToInt32(_configuration["JwtAuthentication:ExpiryInMinutes"]);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtAuthentication:ValidIssuer"],
                audience: _configuration["JwtAuthentication:ValidAudience"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(expiryInMinutes),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            return token;
        }
    }
}
