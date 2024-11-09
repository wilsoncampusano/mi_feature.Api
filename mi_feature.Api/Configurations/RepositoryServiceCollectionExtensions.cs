using mi_feature.Api.Database.Repository;

namespace mi_feature.Api.Configurations
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IPolizaRepository, PolizaRepository>();

            return services;
        }
    }

}
