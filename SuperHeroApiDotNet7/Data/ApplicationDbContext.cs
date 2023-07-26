using Microsoft.EntityFrameworkCore;

namespace SuperHeroApiDotNet7.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=SuperHeroDb; UserId=postgres; password=1121;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
