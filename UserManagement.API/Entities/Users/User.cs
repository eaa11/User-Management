namespace UserManagement.API.Entities.Users
{
    public sealed class User
    {
        public Guid Id { get; init; }

        public Name Name { get; }

        public Email Email { get; }

        public Password Password { get; }

        public DateTimeValue Created { get; }

        public DateTimeValue Modified { get; private set; }

        public DateTimeValue LastLogin { get; private set; }

        public Token Token { get; }

        public bool IsActive { get; private set; }

        private List<Phone> _phones = new();

        public IReadOnlyCollection<Phone> Phones => _phones.AsReadOnly();

        private User(
            Guid id,
            Name name,
            Email email,
            Password password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            IsActive = true;

            DateTime now = DateTime.Now;
            Created = new DateTimeValue(now);
            LastLogin = new DateTimeValue(now);
            Modified = new DateTimeValue(now);
            Token = Token.Generate();
        }

        public static User Create(Name name, Email email, Password password)
        {
            return new User(Guid.NewGuid(), name, email, password);
        }

        internal void ActivateUser()
        {
            if (!IsActive)
            {
                IsActive = true;
                UpdateModifiedDate();
            }
        }

        internal void DeactivateUser()
        {
            if (IsActive)
            {
                IsActive = false;
                UpdateModifiedDate();
            }
        }

        internal void AddPhone(Phone phone)
        {
            if (phone == null)
            {
                throw new ArgumentException("Please, insert a phone number.");
            }
            _phones.Add(phone);
        }

        internal void UpdateLastLoginDate()
        {
            LastLogin = new DateTimeValue(DateTime.Now);
        }

        internal void UpdateModifiedDate()
        {
            Modified = new DateTimeValue(DateTime.Now);
        }
    }
}