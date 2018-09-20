namespace Objects.Tables
{
    public class TableDBUsers
    {
        public string Login { get; private set; }
        public string Passwd { get; private set; }
        public string Vacant { get; private set; }

        public TableDBUsers() { }

        public TableDBUsers(string Login, string Passwd, string Vacant)
        {
            this.Login = Login;
            this.Passwd = Passwd;
            this.Vacant = Vacant;
        }
    }
}
