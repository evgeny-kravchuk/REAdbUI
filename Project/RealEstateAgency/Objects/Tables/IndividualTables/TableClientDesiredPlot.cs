namespace Objects.Tables.IndividualTables
{
    public class TableClientDesiredPlot
    {
        public string City { private set; get; }
        public string Hood { private set; get; }
        public string Street { private set; get; }

        public string Type { private set; get; }
        public string Area { private set; get; }
        public string Status { private set; get; }
        public string Price { private set; get; }

        public TableClientDesiredPlot() { }

        public TableClientDesiredPlot(string City, string Hood, string Street, string Type, string Area, string Status, string Price)
        {
            this.City = City;
            this.Hood = Hood;
            this.Street = Street;

            this.Type = Type;
            this.Area = Area;
            this.Status = Status;
            this.Price = Price;
        }
    }
}
