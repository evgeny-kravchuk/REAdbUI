﻿namespace Objects.Tables
{
    public class TableDesiredFlat
    {
        public string id_desiredObject { private set; get; }
        public string id_client { private set; get; }

        public string City { private set; get; }
        public string Hood { private set; get; }
        public string Street { private set; get; }

        public string Type { private set; get; }
        public string Area { private set; get; }
        public string Status { private set; get; }
        public string Floor { private set; get; }
        public string Room { private set; get; }
        public string Price { private set; get; }

        public TableDesiredFlat() { }

        public TableDesiredFlat(string id_desiredObject, string id_client, string City, string Hood, string Street, string Type, string Area, string Status, string Floor, string Room, string Price)
        {
            this.id_desiredObject = id_desiredObject;
            this.id_client = id_client;

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
