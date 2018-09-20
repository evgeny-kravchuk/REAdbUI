namespace Objects.Tables.IndividualTables
{
    public class TableClientDesiredFlat
    {
        public string City { private set; get; }
        public string Hood { private set; get; }
        public string Street { private set; get; }

        public string Type { private set; get; }
        public string Area { private set; get; }
        public string Status { private set; get; }
        public string Floor { private set; get; }
        public string Room { private set; get; }
        public string Price { private set; get; }

        public TableClientDesiredFlat() { }

        public TableClientDesiredFlat(string City, string Hood, string Street, string Type, string Area, string Status, string Floor, string Room, string Price)
        {
            this.City = City;
            this.Hood = Hood;
            this.Street = Street;

            this.Type = Type;
            this.Area = Area;
            this.Status = Status;
            this.Floor = Floor;
            this.Room = Room;
            this.Price = Price;
        }
    }
}
