using MLDev.AuthSystem.Models.Authentication;
using System.Security.Claims;

namespace MLDev.AuthSystem.Services.Interfaces
{
    public interface IClaimsService
    {
        Task<List<Claim>> GetUserClaimsAsync(User user);
    }
}
