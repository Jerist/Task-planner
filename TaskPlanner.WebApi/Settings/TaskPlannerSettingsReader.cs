namespace TaskPlanner.WebApi.Settings
{
    public class TaskPlannerSettingsReader
    {
        public static TaskPlannerSettings Read(IConfiguration configuration)
        {
            return new TaskPlannerSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                TaskPlannerDbContextConnectionString = configuration.GetValue<string>("TaskPlannerDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}
