namespace Objects.Tables
{
    public class TableStaff
    {
        public string id_employee { private set; get; }
        public string Login { private set; get; }

        public string LastName { private set; get; }
        public string FirstName { private set; get; }
        public string Patronymic { private set; get; }

        public string Sex { private set; get; }
        public string DateOfBirth { private set; get; }
        public string Position { private set; get; }
        public string PhoneNumber { private set; get; }

        public TableStaff() { }

        public TableStaff(string id_employee, string Login, string LastName, string FirstName, string Patronymic, string Sex, string DateOfBirth, string Position, string PhoneNumber)
        {
            this.id_employee = id_employee;
            this.Login = Login;

            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Patronymic = Patronymic;

            this.Sex = Sex;
            this.DateOfBirth = DateOfBirth;
            this.Position = Position;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
