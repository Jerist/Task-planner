using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.DataAccess.Entities
{
    [Table("task_statuses")]
    public class TaskStatus: BaseEntity
    {
        public string Status { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
