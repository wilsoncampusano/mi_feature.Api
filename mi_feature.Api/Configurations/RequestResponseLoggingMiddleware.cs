namespace mi_feature.Api.Configurations
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var request = httpContext.Request;
            _logger.LogInformation($"Solicitud entrante: {request.Method} {request.Path}");

            var originalBodyStream = httpContext.Response.Body;
            using (var newBodyStream = new MemoryStream())
            {
                httpContext.Response.Body = newBodyStream;

                await _next(httpContext);

                newBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = new StreamReader(newBodyStream).ReadToEnd();
                _logger.LogInformation($"Respuesta: {responseBody}");

                newBodyStream.Seek(0, SeekOrigin.Begin);
                await newBodyStream.CopyToAsync(originalBodyStream);
            }
        }
    }

}
