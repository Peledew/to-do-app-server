using Microsoft.EntityFrameworkCore;
using ToDoAppServer.Domain.Entities;

namespace ToDoAppServer.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationships
            modelBuilder.Entity<Project>()
            .HasOne(p => p.Creator)
            .WithMany(u => u.Projects)
            .HasForeignKey(p => p.CreatorId)
            .OnDelete(DeleteBehavior.SetNull);

            //Enum conversion
            modelBuilder.Entity<User>()
            .Property(u => u.Gender)
            .HasConversion<string>();

            modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

            //Unique constraints
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
