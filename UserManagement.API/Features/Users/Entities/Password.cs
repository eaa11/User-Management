using System.Text.RegularExpressions;
using UserManagement.API.Commom;

namespace UserManagement.API.Features.Users.Entities
{
    public record Password
    {
        private static readonly string DefaultPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$";
        public string Value { get; }

        public Password(string value, string? pattern = null)
        {
            pattern ??= DefaultPattern;
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ValidationException("The password does not meet the required format.");
            }
            Value = value;
        }

        public override string ToString() => Value;
    }
}