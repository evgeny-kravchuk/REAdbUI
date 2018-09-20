namespace DatabaseLayer.DLObjects
{
    public class StaffMember
    {
        public string id_employee { set; get; }
        public string Login { set; get; }

        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Patronymic { set; get; }

        public string Sex { set; get; }
        public string DateOfBirth { set; get; }
        public string Position { set; get; }
        public string PhoneNumber { set; get; }

        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string NewLogin { set; get; }
    }
}
