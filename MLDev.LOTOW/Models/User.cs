using Microsoft.AspNetCore.Identity;

namespace MLDev.LOTOW.Models
{
    public class User: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName{ get; set; }
    }
}
