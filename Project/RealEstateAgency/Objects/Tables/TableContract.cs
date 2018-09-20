namespace Objects.Tables
{
    public class TableContract
    {
        public string id_contract { private set; get; }
        public string id_client { private set; get; }
        public string id_employee { private set; get; }
        public string id_object { private set; get; }
        public string id_owner { private set; get; }

        public string ContractType { private set; get; }
        public string StartDate { private set; get; }
        public string FinishDate { private set; get; }
        public string Price { private set; get; }

        public TableContract() { }

        public TableContract(string id_contract, string id_client, string id_employee, string id_object, string id_owner, string ContractType, string StartDate, string FinishDate, string Price)
        {
            this.id_contract = id_contract;
            this.id_client = id_client;
            this.id_employee = id_employee;
            this.id_object = id_object;
            this.id_owner = id_owner;

            this.ContractType = ContractType;
            this.StartDate = StartDate;
            this.FinishDate = FinishDate;
            this.Price = Price;
        }
    }
}
