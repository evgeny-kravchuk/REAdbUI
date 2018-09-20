namespace Objects.Tables
{
    public class TablePosition
    {
        public string Position { private set; get; }
        public string Salary { private set; get; }

        public TablePosition() { }

        public TablePosition(string Position, string Salary)
        {
            this.Position = Position;
            this.Salary = Salary;
        }
    }
}
