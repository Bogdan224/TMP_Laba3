namespace TMP_Laba3_Authorization
{
    public enum UserRole
    {
        Boss, HR, OO
    }

    public class Person
    {
        protected string _name { get; private set; }
        protected string _password { get; private set; }

        protected UserRole _role { get; private set; }

        public string Name
        {
            get { return _name; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _name = value;
            }
        }

        public string Password
        {
            get { return _password; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _password = value;
            }
        }

        public UserRole Role
        {
            get { return _role; }

            set
            {
                _role = value;
            }
        }

        public Person(string name, string password, UserRole role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
    }
}
