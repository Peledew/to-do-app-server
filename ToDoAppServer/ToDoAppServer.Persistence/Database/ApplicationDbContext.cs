using Microsoft.EntityFrameworkCore;
using ToDoAppServer.Domain.Entities;

namespace ToDoAppServer.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationships
            modelBuilder.Entity<Project>()
            .HasOne(p => p.Creator)
            .WithMany(u => u.Projects)
            .HasForeignKey(p => p.CreatorId)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Domain.Entities.Task>()
            .HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskTag>()
            .HasOne(tt => tt.Task)
            .WithMany(t => t.TaskTags)
            .HasForeignKey(tt => tt.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskTag>()
            .HasOne(tt => tt.Tag)
            .WithMany(tg => tg.TaskTags)
            .HasForeignKey(tt => tt.TagId)
            .OnDelete(DeleteBehavior.Cascade);

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

            //Keys
            modelBuilder.Entity<TaskTag>()
            .HasKey(tt => new { tt.TaskId, tt.TagId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }
    }
}
