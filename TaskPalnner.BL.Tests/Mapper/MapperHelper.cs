
using AutoMapper;
using TaskPalnner.WebApi.Mapper;

namespace TaskPalnner.BL.Tests.Mapper
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(typeof(AdminsServiceProfile));
            });
            Mapper = new AutoMapper.Mapper(config);
        }

        public static IMapper Mapper { get; }
    }
}
