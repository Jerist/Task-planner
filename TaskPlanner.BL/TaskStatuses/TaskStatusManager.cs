using AutoMapper;
using TaskPlanner.BL.Exceptions;
using TaskPlanner.Repository;
using TaskPlanner.DataAccess.Entities;
using TaskPlanner.BL.TaskStatuses.Entities;

namespace TaskPlanner.BL.TaskStatuses
{
    public class TaskStatusManager: ITaskStatusManager
    {
        private readonly IRepository<DataAccess.Entities.TaskStatus> _repository;
        private readonly IMapper _mapper;

        public TaskStatusManager(IRepository<DataAccess.Entities.TaskStatus> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TaskStatusModel CreateTaskStatus(CreateTaskStatusModel model)
        {

            var entity = _mapper.Map<DataAccess.Entities.TaskStatus>(model);

            _repository.Save(entity);

            return _mapper.Map<TaskStatusModel>(entity);
        }

        public void DeleteTaskStatus(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            _repository.Delete(entity);
        }

        public TaskStatusModel UpdateTaskStatus(Guid id, UpdateTaskStatusModel model)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            entity.Status = model.StatusName;
            _repository.Save(entity);
            return _mapper.Map<TaskStatusModel>(entity);
        }
    }
}
