namespace BusinessLogic.BLObjects
{
    public class ContractMember
    {
        public string id_contract { set; get; }
        public string id_client { set; get; }
        public string id_employee { set; get; }
        public string id_object { set; get; }
        public string id_owner { set; get; }

        public string ContractType { set; get; }
        public string StartDate { set; get; }
        public string FinishDate { set; get; }
        public string Price { set; get; }
    }
}
