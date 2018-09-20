namespace DatabaseLayer.DLObjects
{
    public class DesiredPlotMember
    {
        public string id_desiredObject { set; get; }
        public string id_client { set; get; }

        public string City { set; get; }
        public string Hood { set; get; }
        public string Street { set; get; }

        public string Type { set; get; }
        public string Area { set; get; }
        public string Status { set; get; }
        public string Price { set; get; }
    }
}
