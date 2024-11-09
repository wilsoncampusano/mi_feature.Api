namespace mi_feature.Api.Configurations
{


    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddControllerConfigServices(this IServiceCollection services)
        {
            services.AddControllers(options => { options.Conventions.Add(new RoutePrefixConvention("mi-feature")); });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }

}
