using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.DataAccess.Entities
{
    [Table("projects")]
    public class Project: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<TaskWithinProject> TasksWithinProject { get; set; }
    }
}
