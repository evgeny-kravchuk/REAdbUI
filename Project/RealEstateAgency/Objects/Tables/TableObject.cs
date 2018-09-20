namespace Objects.Tables
{
    public class TableObject
    {
        public string id_object { private set; get; }
        public string id_owner { private set; get; }

        public string PostCode { private set; get; }
        public string City { private set; get; }
        public string Hood { private set; get; }
        public string Street { private set; get; }
        public string HouseNumber { private set; get; }
        public string FlatNumber { private set; get; }

        public string Type { private set; get; }
        public string Price { private set; get; }

        public TableObject() { }

        public TableObject(string id_object, string id_owner, string PostCode, string City, string Hood, string Street, string HouseNumber, string FlatNumber, string Type, string Price)
        {
            this.id_object = id_object;
            this.id_owner = id_owner;

            this.PostCode = PostCode;
            this.City = City;
            this.Hood = Hood;
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.FlatNumber = FlatNumber;

            this.Type = Type;
            this.Price = Price;
        }
    }
}
