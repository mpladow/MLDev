using Microsoft.AspNetCore.Identity;
using MLDev.LOTOW.Models.Authentication;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services.Interfaces;
using System.Security.Claims;

namespace MLDev.LOTOW.Services
{
    public class ClaimsService : IClaimsService
    {
        private UserManager<User> _userManager;

        public ClaimsService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<Claim>> GetUserClaimsAsync(User user)
        {
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
            };
            // get roles
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            return userClaims;
        }
    }
}
