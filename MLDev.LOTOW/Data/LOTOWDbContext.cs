using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Data
{
    public class LOTOWDbContext: DbContext
    {
        public LOTOWDbContext(DbContextOptions<LOTOWDbContext> options):base(options) { 
        
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("LOTOW");
            modelBuilder.Entity<Character>().ToTable("Characters");
            modelBuilder.Entity<Stat>().ToTable("Stats");
            modelBuilder.Entity<StatModifier>().ToTable("StatModifiers");
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<StatModifier> StatModifier { get; set; }
    }
}
