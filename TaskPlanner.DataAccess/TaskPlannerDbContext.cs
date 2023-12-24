using Microsoft.EntityFrameworkCore;
using TaskPlanner.DataAccess.Entities;

namespace TaskPlanner.DataAccess
{
    public class TaskPlannerDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<TaskPriority> TaskPriorities { get; set; }
        public DbSet<Entities.TaskStatus> TaskStatuses { get; set; }
        public DbSet<TaskWithinProject> TasksWithProjects { get; set; }
        public DbSet<User> Users { get; set; }

        public TaskPlannerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasKey(x => x.Id);
            modelBuilder.Entity<Admin>().HasIndex(x => x.ExternalId).IsUnique();


            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<Project>().HasKey(x => x.Id);
            modelBuilder.Entity<Project>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<Project>().HasOne(x => x.User)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<TaskPriority>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskPriority>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<Entities.TaskStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<Entities.TaskStatus>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<Entities.Task>().HasKey(x => x.Id);
            modelBuilder.Entity<Entities.Task>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<Entities.Task>().HasOne(x => x.User)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Entities.Task>().HasOne(x => x.TaskStatus)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TaskStatusId);
            modelBuilder.Entity<Entities.Task>().HasOne(x => x.TaskPriority)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TaskPriorityId);

            modelBuilder.Entity<TaskWithinProject>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskWithinProject>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<TaskWithinProject>().HasOne(x => x.Task)
                .WithMany(x => x.TaskWithinProjects)
                .HasForeignKey(x => x.TaskId);
            modelBuilder.Entity<TaskWithinProject>().HasOne(x => x.Project)
                .WithMany(x => x.TasksWithinProject)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}
