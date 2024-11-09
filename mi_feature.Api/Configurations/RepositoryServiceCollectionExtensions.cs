namespace mi_feature.Api.Configurations
{
    using mi_feature.Api.Database.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IPolizaRepository, PolizaRepository>();

            return services;
        }
    }

}
