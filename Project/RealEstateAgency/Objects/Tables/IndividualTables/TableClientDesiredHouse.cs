namespace Objects.Tables.IndividualTables
{
    public class TableClientDesiredHouse
    {
        public string City { private set; get; }
        public string Hood { private set; get; }
        public string Street { private set; get; }

        public string Type { private set; get; }
        public string Area { private set; get; }
        public string Status { private set; get; }
        public string NumberOfStoreys { private set; get; }
        public string Room { private set; get; }
        public string Price { private set; get; }

        public TableClientDesiredHouse() { }

        public TableClientDesiredHouse(string City, string Hood, string Street, string Type, string Area, string Status, string NumberOfStoreys, string Room, string Price)
        {
            this.City = City;
            this.Hood = Hood;
            this.Street = Street;

            this.Type = Type;
            this.Area = Area;
            this.Status = Status;
            this.NumberOfStoreys = NumberOfStoreys;
            this.Room = Room;
            this.Price = Price;
        }
    }
}
