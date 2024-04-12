using Hangfire;
using Hangfire.Storage.SQLite;

namespace TaskScheduler.Configurations
{
    public static class ConfigServices
    {
        public static void AddServices(this IServiceCollection serviceCollection,
            IConfiguration config)
        {
            // Add Hangfire services.
            serviceCollection.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage(config.GetConnectionString("HangfireConnection")));

            // Add the processing server as IHostedService
            serviceCollection.AddHangfireServer();
        }
    }
}
