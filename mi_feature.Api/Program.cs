using mi_feature.Api.Configurations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDatabaseServices();
builder.Services.AddRepositoryServices();
builder.Services.AddControllerConfigServices();
builder.Services.AddCQRSMediatorServices();
builder.Services.AddSerilogConfigServices(builder);
builder.Services.AddExceptionHandlingServices();

var app = builder.Build();

app.UseSerilogRequestLogging(options =>
{
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestPath", httpContext.Request.Path); 
        diagnosticContext.Set("RequestMethod", httpContext.Request.Method); 
    };
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
