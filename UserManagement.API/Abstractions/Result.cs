namespace UserManagement.API.Abstractions
{
    public class Result<T>
    {
        public T? Value { get; }

        public string? ErrorMessage { get; }

        public Result(T value)
        {
            Value = value;
        }

        public Result(string error)
        {
            ErrorMessage = error;
        }

        public static Result<T> Success(T value) => new Result<T>(value);

        public static Result<T> Failure(string error) => new Result<T>(error);
    }
}