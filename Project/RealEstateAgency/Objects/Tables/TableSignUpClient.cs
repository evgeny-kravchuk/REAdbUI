namespace Objects.Tables
{
    public class TableSignUpClient
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Patronymic { get; private set; }

        public string PhoneNumber { get; private set; }

        public TableSignUpClient() { }

        public TableSignUpClient(string Login, string Password, string LastName, string FirstName, string Patronymic, string PhoneNumber)
        {
            this.Login = Login;
            this.Password = Password;

            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Patronymic = Patronymic;

            this.PhoneNumber = PhoneNumber;
        }
    }
}
