using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskPlanner.DataAccess;
using TaskPlanner.WebApi.Settings;

namespace TaskPlanner.UnitTests.Repository
{
    public class RepositoryTestsBaseClass
    {
        public RepositoryTestsBaseClass()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Test.json", optional: true)
                .Build();

            Settings = TaskPlannerSettingsReader.Read(configuration);
            ServiceProvider = ConfigureServiceProvider();

            DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<TaskPlannerDbContext>>();
        }

        private IServiceProvider ConfigureServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContextFactory<TaskPlannerDbContext>(
                options => { options.UseSqlServer(Settings.TaskPlannerDbContextConnectionString); },
                ServiceLifetime.Scoped);
            return serviceCollection.BuildServiceProvider();
        }

        protected readonly TaskPlannerSettings Settings;
        protected readonly IDbContextFactory<TaskPlannerDbContext> DbContextFactory;
        protected readonly IServiceProvider ServiceProvider;
    }
}
