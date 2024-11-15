using System.Text.Json.Serialization;

namespace mi_feature.Api.Controllers.Helpers
{
    public class ApiResponse<T>
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object?> Extensions { get; set; } = new Dictionary<string, object?>(StringComparer.Ordinal);
        public T Data { get; set; }

       

        public ApiResponse(int statusCode, bool success, string message, T data)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Request successful")
        {
            return new ApiResponse<T>(200, true, message, data);
        }

        public static ApiResponse<T> BadRequestResponse(T data , string message = "Invalid request")
        {
            return new ApiResponse<T>(400, false, message, data);
        }

        public static ApiResponse<T> NotFoundResponse(string message = "Resource not found")
        {
            return new ApiResponse<T>(404, false, message, default);
        }

        public static ApiResponse<T> InternalServerErrorResponse(string message = "Internal server error")
        {
            return new ApiResponse<T>(500, false, message, default);
        }
    }

}
