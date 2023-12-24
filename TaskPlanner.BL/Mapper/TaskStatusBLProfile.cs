using AutoMapper;
using TaskPlanner.BL.TaskStatuses.Entities;
using TaskPlanner.DataAccess.Entities;
using TaskStatus = TaskPlanner.DataAccess.Entities.TaskStatus;

namespace TaskPlanner.BL.Mapper
{
    public class TaskStatusBLProfile : Profile
    {
        public TaskStatusBLProfile()
        {
            CreateMap<TaskStatus, TaskStatusModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateTaskStatusModel, TaskStatus>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.Tasks, y => y.Ignore());
        }
    }
}
