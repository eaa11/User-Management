using UserManagement.API.Commom;

namespace UserManagement.API.Features.Commom
{
    public record DateTimeValue
    {
        public DateTime Value { get; }

        public DateTimeValue(DateTime value)
        {
            if (value > DateTime.Now)
            {
                throw new ValidationException("Date cannot be in the future.");
            }
            Value = value;
        }
        public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
    }
}