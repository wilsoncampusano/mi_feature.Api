using Serilog;

namespace mi_feature.Api.Configurations
{


    public static class SerilogServiceCollectionExtensions
    {
        public static IServiceCollection AddSerilogConfigServices(this IServiceCollection services, WebApplicationBuilder builder )
        {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()  // Establece el nivel de log a Debug o superior
                    .WriteTo.Console()     // Logs en la consola
                    .WriteTo.File("./log.txt", rollingInterval: RollingInterval.Day) // Logs en archivo
                    .WriteTo.Seq("http://localhost:5341") // Logs a servidor Seq (si tienes uno)
                    .Enrich.FromLogContext()  // Enriquecer logs con contexto
                    .Enrich.WithProperty("Application", "MiMicroservicio")  // Agregar propiedad global
                    .CreateLogger();

            builder.Host.UseSerilog();

            return services;
        }
    }

}
