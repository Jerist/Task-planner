using TaskPlanner.BL.TaskStatuses.Entities;

namespace TaskPlanner.BL.TaskStatuses
{
    public interface ITaskStatusManager
    {
        TaskStatusModel CreateTaskStatus(CreateTaskStatusModel model);
        void DeleteTaskStatus(Guid id);
        TaskStatusModel UpdateTaskStatus(Guid id, UpdateTaskStatusModel model);
    }
}
