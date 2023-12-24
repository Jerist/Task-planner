using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.DataAccess.Entities
{
    [Table("tasks_within_projects")]
    public class TaskWithinProject: BaseEntity
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
