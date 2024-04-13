namespace FinanceAPI.Models
{
    public class EFSeller:EFBaseModel
    {
/*
        public EFDoctor() { }*/

        public string Name { get; set; }
        public string Description { get; set; }
        public int BankNumber { get; set; }
        public List<EFBuyer> EFBuyers{ get; set; } = new List<EFBuyer>();
    }
}
