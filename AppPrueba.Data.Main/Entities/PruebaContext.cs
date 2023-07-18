using Microsoft.EntityFrameworkCore;

namespace AppPrueba.Data.Main.Entities
{
    public partial class PruebaContext : DbContext
    {
        public DbSet<UsersEntity> Users { get; set; }

        public PruebaContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\myServerBBDD;Database=mytasks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersEntity>(entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.ToTable("Users");
            });
        }
    }
}
