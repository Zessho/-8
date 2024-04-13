namespace FinanceAPI.Models
{
    public class EFBuyer:EFBaseModel
    {
/*
        public EFPatient() { }*/
        public string Name { get; set; }
       
        public int BankNumber { get; set; }

        public List<EFSeller> Sellers { get; set; } = new List<EFSeller>();

    }
}
