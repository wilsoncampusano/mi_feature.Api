namespace mi_feature.Api.Configurations
{


    public static class ExceptionHandlingServiceCollectionExtensions
    {
        public static IServiceCollection AddExceptionHandlingServices(this IServiceCollection services)
        {

            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
