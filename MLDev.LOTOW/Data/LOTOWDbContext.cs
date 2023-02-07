using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Data
{
    public class LOTOWDbContext: DbContext
    {
        public LOTOWDbContext(DbContextOptions<LOTOWDbContext> options):base(options) { 
        
        } 

        public DbSet<Character> Character { get; set; }
    }
}
