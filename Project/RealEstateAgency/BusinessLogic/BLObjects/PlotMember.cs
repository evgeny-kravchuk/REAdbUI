﻿namespace BusinessLogic.BLObjects
{
    public class PlotMember
    {
        public string id_object { set; get; }
        public string id_owner { set; get; }

        public string PostCode { set; get; }
        public string City { set; get; }
        public string Hood { set; get; }
        public string Street { set; get; }
        public string HouseNumber { set; get; }
        public string FlatNumber { set; get; }

        public string Type { set; get; }
        public string Area { set; get; }
        public string Status { set; get; }
        public string Price { set; get; }
    }
}
