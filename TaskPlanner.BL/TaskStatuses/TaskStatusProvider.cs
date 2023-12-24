using AutoMapper;
using TaskPlanner.BL.Exceptions;
using TaskPlanner.BL.TaskStatuses.Entities;
using TaskPlanner.Repository;
using TaskPlanner.DataAccess.Entities;

namespace TaskPlanner.BL.TaskStatuses
{
    public class TaskStatusProvider: ITaskStatusProvider
    {
        private readonly IRepository<DataAccess.Entities.TaskStatus> _repository;
        private readonly IMapper _mapper;

        public TaskStatusProvider(IRepository<DataAccess.Entities.TaskStatus> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TaskStatusModel GetTaskStatusInfo(Guid id)
        {
            var resume = _repository.GetById(id);
            if (resume is null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<TaskStatusModel>(resume);
        }

        public IEnumerable<TaskStatusModel> GetTaskStatus(TaskStatusModelFilter filter = null)
        {
            var name = filter?.StatusName;

            var companies = _repository.GetAll(x =>
                name == null || x.Status == name);

            return _mapper.Map<IEnumerable<TaskStatusModel>>(companies);
        }
    }
}
