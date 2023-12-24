using TaskPlanner.BL.TaskStatuses.Entities;

namespace TaskPlanner.BL.TaskStatuses
{
    public interface ITaskStatusProvider
    {
        IEnumerable<TaskStatusModel> GetTaskStatus(TaskStatusModelFilter filter = null);
        TaskStatusModel GetTaskStatusInfo(Guid id);
    }
}
