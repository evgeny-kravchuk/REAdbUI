﻿namespace Objects.Tables.IndividualTables
{
    public class TableFindFlat
    {
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

        public TableFindFlat() { }

        public TableFindFlat(string PostCode, string City, string Hood, string Street, string HouseNumber, string FlatNumber, string Type, string Area, string Status, string Floor, string Room, string Price)
        {
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
