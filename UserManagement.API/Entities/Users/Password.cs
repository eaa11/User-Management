using System.Text.RegularExpressions;

namespace UserManagement.API.Entities.Users
{
    public record Password
    {
        public string Value { get; }
        public const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
        public Password(string value)
        {
            if (!Regex.IsMatch(value, PASSWORD_PATTERN))
            {
                throw new ArgumentException("The password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a number, and a special character.");
            }
            Value = value;
        }
    }
}