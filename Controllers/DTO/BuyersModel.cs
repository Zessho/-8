using FinanceAPI.Replicates;

namespace FinanceAPI.Controllers.DTO
{
    public class BuyersModel
    {
        public BuyersModel() { }
        public BuyersModel(Buyers context)
        {
            id = context.Id;
            name = context.Name;
          
            BankNumber = context.BankNumber;
        }

        public int id { get; set; }
        public string name { get; set; }
       
        public int BankNumber { get; set; }
    }
}
