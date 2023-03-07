using Microsoft.AspNetCore.Identity;

namespace MLDev.Data.Models.Authentication
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole(string name)
        {
            Name = name;
        }
    }
}
