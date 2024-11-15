using mi_feature.Api.Controllers.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace mi_feature.Api.Configurations
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var apiResponse = ApiResponse<object>.BadRequestResponse(null);

            apiResponse.Endpoint = httpContext.Request.Path;

            if (exception is FluentValidation.ValidationException fluentException)
            {
                List<string> validationErrors = new List<string>();
                foreach (var error in fluentException.Errors)
                {
                    validationErrors.Add(error.ErrorMessage);
                }
                apiResponse.Extensions.Add("errors", validationErrors);
            }

            else
            {
                apiResponse.Message = exception.Message;
            }

            logger.LogError("{apiResponseMessage}", apiResponse.Message);

            await httpContext.Response.WriteAsJsonAsync(apiResponse, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
