using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MLDev.Data.Data.Entities;
using MLDev.Data.Models.Authentication;

namespace MLDev.Data.Data
{
    public class LOTOWDbContext: IdentityDbContext<User, AppRole,Guid>
    {
        public LOTOWDbContext(DbContextOptions<LOTOWDbContext> options):base(options) { 
        
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Character>().ToTable("Characters");
            //modelBuilder.Entity<Stat>().ToTable("Stats");
            //modelBuilder.Entity<StatModifier>().ToTable("StatModifiers");
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<StatModifier> StatModifiers { get; set; }
        public DbSet<CharacterStat> CharacterStats { get; set; }
    }
}
