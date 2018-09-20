namespace Objects.Tables.IndividualTables
{
    public class TableStaffContractInfo
    {
        public string City { private set; get; }
        public string Street { private set; get; }
        public string HouseNumber { private set; get; }
        public string FlatNumber { private set; get; }

        public string ContractType { private set; get; }
        public string StartDate { private set; get; }
        public string FinishDate { private set; get; }
        public string Price { private set; get; }

        public TableStaffContractInfo() { }

        public TableStaffContractInfo(string City, string Street, string HouseNumber, string FlatNumber, string ContractType, string StartDate, string FinishDate, string Price)
        {
            this.City = City;
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.FlatNumber = FlatNumber;

            this.ContractType = ContractType;
            this.StartDate = StartDate;
            this.FinishDate = FinishDate;
            this.Price = Price;
        }
    }
}
