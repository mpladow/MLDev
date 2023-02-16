using Microsoft.AspNetCore.Identity;

namespace MLDev.LOTOW.Models.Authentication
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole(string name)
        {
            Name = name;
        }
    }
}
