using Microsoft.AspNetCore.Identity;

namespace MLDev.LOTOW.Models
{
    public class AppRole: IdentityRole<Guid>
    {
        public AppRole(string name)
        {
            Name = name;
        }
    }
}
