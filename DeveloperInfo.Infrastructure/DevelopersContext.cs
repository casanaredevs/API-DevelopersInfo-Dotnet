using DeveloperInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperInfo.Infrastructure
{
    public class DevelopersContext : DbContext
    {
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<DeveloperSocialNetwork> DeveloperSocialNetworks { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public DevelopersContext(DbContextOptions<DevelopersContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DatabaseSeed.SeedTechnologies(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}