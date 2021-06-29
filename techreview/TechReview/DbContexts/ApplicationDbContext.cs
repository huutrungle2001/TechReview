using TechReview.Entities;
using Microsoft.EntityFrameworkCore;


namespace TechReview.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Devices> Devices { get; private set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Devices>().Property(b => b.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
        }

    }
}
