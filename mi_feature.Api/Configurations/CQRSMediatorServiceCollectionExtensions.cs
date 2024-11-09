using System.Reflection;
using FluentValidation;

namespace mi_feature.Api.Configurations
{


    public static class CQRSMediatorServiceCollectionExtensions
    {
        public static IServiceCollection AddCQRSMediatorServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); cfg.AddOpenBehavior(typeof(ValidationBehavior<,>)); });

            return services;
        }
    }
}
