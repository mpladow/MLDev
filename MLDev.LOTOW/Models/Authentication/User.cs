using Microsoft.AspNetCore.Identity;

namespace MLDev.LOTOW.Models.Authentication
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
