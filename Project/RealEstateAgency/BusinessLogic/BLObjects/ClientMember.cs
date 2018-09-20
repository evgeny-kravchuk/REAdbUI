namespace BusinessLogic.BLObjects
{
    public class ClientMember
    {
        public string id_client { set; get; }
        public string Login { get; set; }

        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Patronymic { get; set; }

        public string PhoneNumber { set; get; }

        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string NewLogin { set; get; }
    }
}
