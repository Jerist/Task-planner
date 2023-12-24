using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.DataAccess.Entities
{
    [Table("task_priorities")]
    public class TaskPriority: BaseEntity
    {
        public string Priority { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
