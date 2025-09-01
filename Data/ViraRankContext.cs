using Microsoft.EntityFrameworkCore;
using ViraRankApi.Models;

namespace ViraRankApi.Data
{
    public class ViraRankContext : DbContext
    {
        public ViraRankContext(DbContextOptions<ViraRankContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                
                entity.HasKey(e => e.Id).HasName("PK_User");

                
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.UserName).HasColumnName("UserName").HasColumnType("varchar(50)").IsRequired();
                entity.Property(e => e.Email).HasColumnName("Email").HasColumnType("varchar(75)").IsRequired();
                entity.Property(e => e.BirthDate).HasColumnName("birth_date").HasColumnType("date").IsRequired();
                entity.Property(e => e.Gender).HasColumnName("gender").HasColumnType("bit").IsRequired();

                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasColumnType("varbinary(64)");
                entity.Property(e => e.PasswordSalt).HasColumnName("password_salt").HasColumnType("varbinary(32)");

                
                entity.HasIndex(e => e.Email).IsUnique().HasDatabaseName("UX_User_Email");
                entity.HasIndex(e => e.UserName).IsUnique().HasDatabaseName("UX_User_UserName");
            });
        }
    }
}
