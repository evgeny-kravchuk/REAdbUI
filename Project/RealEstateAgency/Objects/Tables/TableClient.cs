namespace Objects.Tables
{
    public class TableClient
    {
        public string id_client { private set; get; }
        public string Login { private set; get; }

        public string LastName { private set; get; }
        public string FirstName { private set; get; }
        public string Patronymic { private set; get; }

        public string PhoneNumber { private set; get; }

        public TableClient() { }

        public TableClient(string id_client, string Login, string LastName, string FirstName, string Patronymic, string PhoneNumber)
        {
            this.id_client = id_client;
            this.Login = Login;

            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Patronymic = Patronymic;

            this.PhoneNumber = PhoneNumber;
        }
    }
}
