using Microsoft.AspNetCore.Identity;

namespace MLDev.AuthSystem.Models.Authentication
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole(string name)
        {
            Name = name;
        }
    }
}
