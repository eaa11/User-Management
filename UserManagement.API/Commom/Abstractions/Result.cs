namespace UserManagement.API.Commom.Abstractions
{
    public class Result<T>
    {
        public T? Value { get; }

        public string? ErrorMessage { get; }

        public bool IsSuccess { get; }

        public int StatusCode { get; }

        private Result(T value, int statusCode)
        {
            Value = value;
            IsSuccess = true;
            StatusCode = statusCode;
        }

        private Result(string error, int statusCode)
        {
            ErrorMessage = error;
            IsSuccess = false;
            StatusCode = statusCode;
        }

        public static Result<T> Success(T value, int statusCode = 200) =>
            new Result<T>(value, statusCode);

        public static Result<T> Failure(string error, int statusCode = 400) =>
            new Result<T>(error, statusCode);
    }
}