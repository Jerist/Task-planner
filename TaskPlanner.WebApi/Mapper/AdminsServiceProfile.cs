
using AutoMapper;
using TaskPlanner.BL.Admins.Entities;

namespace TaskPlanner.WebApi.Mapper
{
    public class AdminsServiceProfile : Profile
    {
        public AdminsServiceProfile()
        {
            CreateMap<AdminsFilter, AdminModelFilter>();
            CreateMap<CreateAdminRequest, CreateAdminModel>();
            CreateMap<UpdateAdminRequest, UpdateAdminModel>();
        }
    }
}
