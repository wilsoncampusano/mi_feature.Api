using mi_feature.Api.Database.DB;

namespace mi_feature.Api.Configurations
{
    public static class DatabaseServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

            return services;
        }
    }
}
