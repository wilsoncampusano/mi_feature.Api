namespace mi_feature.Api.Configurations
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public static Result<T> SuccessResult(T data) => new Result<T> { Success = true, Data = data, StatusCode = 200 };
        public static Result<T> NotFound(string message) => new Result<T> { Success = false, Message = message, StatusCode = 404 };
        public static Result<T> BadRequest(string message) => new Result<T> { Success = false, Message = message, StatusCode = 400 };
        public static Result<T> ServerError(string message) => new Result<T> { Success = false, Message = message, StatusCode = 500 };
        public Result(bool success, int statusCode, string message, T data)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public Result() { }
    }

}
