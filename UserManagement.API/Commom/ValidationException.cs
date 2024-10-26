namespace UserManagement.API.Commom
{
    public class ValidationException : Exception
    {
        public string ErrorCode { get; }

        public ValidationException(string message, string errorCode = "VALIDATION_ERROR")
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}