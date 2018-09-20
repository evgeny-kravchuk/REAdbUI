namespace Objects.Tables.IndividualTables
{
    public class TableClientPersonalInfo
    {
        public string Login { private set; get; }

        public string LastName { private set; get; }
        public string FirstName { private set; get; }
        public string Patronymic { private set; get; }

        public string PhoneNumber { private set; get; }

        public TableClientPersonalInfo() { }

        public TableClientPersonalInfo(string Login, string LastName, string FirstName, string Patronymic, string PhoneNumber)
        {
            this.Login = Login;

            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Patronymic = Patronymic;

            this.PhoneNumber = PhoneNumber;
        }
    }
}
