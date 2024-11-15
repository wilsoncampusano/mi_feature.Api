using mi_feature.Api.Controllers.Helpers;
using Microsoft.AspNetCore.Diagnostics;

namespace mi_feature.Api.Configurations
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var apiResponse = ApiResponse<object>.BadRequestResponse(null);

            if (exception is FluentValidation.ValidationException fluentException)
                apiResponse.Extensions.Add("errors", fluentException.Errors.Select(e => e.ErrorMessage));
            else
                apiResponse.Message = exception.Message;
            
            logger.LogError("{apiResponseMessage}", apiResponse.Message);
            httpContext.Response.StatusCode = apiResponse.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(apiResponse, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
