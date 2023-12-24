using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.DataAccess.Entities
{
    [Table("tasks")]
    public class Task: BaseEntity
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int TaskPriorityId { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public int TaskStatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<TaskWithinProject> TaskWithinProjects { get; set; }

    }
}
