using Microsoft.EntityFrameworkCore;
using ViraRankCleanApi.Models;

namespace ViraRankCleanApi.Data
{
    public class ViraRankContext : DbContext
    {
        public ViraRankContext(DbContextOptions<ViraRankContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
    }
}
