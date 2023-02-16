using MLDev.LOTOW.Models.Authentication;
using System.Security.Claims;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface IClaimsService
    {
        Task<List<Claim>> GetUserClaimsAsync(User user);
    }
}
