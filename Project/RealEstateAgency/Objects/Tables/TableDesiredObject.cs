namespace Objects.Tables
{
    public class TableDesiredObject
    {
        public string id_desiredObject { private set; get; }
        public string id_client { private set; get; }

        public string City { private set; get; }
        public string Hood { private set; get; }
        public string Street { private set; get; }

        public string Type { private set; get; }
        public string Price { private set; get; }

        public TableDesiredObject() { }

        public TableDesiredObject(string id_desiredObject, string id_client, string City, string Hood, string Street, string Type, string Price)
        {
            this.id_desiredObject = id_desiredObject;
            this.id_client = id_client;

            this.City = City;
            this.Hood = Hood;
            this.Street = Street;

            this.Type = Type;
            this.Price = Price;
        }
    }
}
