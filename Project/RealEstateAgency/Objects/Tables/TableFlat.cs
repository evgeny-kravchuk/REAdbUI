namespace Objects.Tables
{
    public class TableFlat
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
        public string Area { private set; get; }
        public string Status { private set; get; }
        public string Floor { private set; get; }
        public string Room { private set; get; }
        public string Price { private set; get; }

        public TableFlat() { }

        public TableFlat(string id_object, string id_owner, string PostCode, string City, string Hood, string Street, string HouseNumber, string FlatNumber, string Type, string Area, string Status, string Floor, string Room, string Price)
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
            this.Area = Area;
            this.Status = Status;
            this.Floor = Floor;
            this.Room = Room;
            this.Price = Price;
        }
    }
}
