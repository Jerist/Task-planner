namespace TaskPlanner.WebApi.Settings
{
    public class TaskPlannerSettings
    {
        public Uri ServiceUri { get; set; }
        public string TaskPlannerDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
