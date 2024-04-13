using FinanceAPI.Context;
using FinanceAPI.Replicates;

namespace FinanceAPI.Controllers.DTO
{
    public class SellerModel
    {
        public SellerModel() { }
        public SellerModel(Seller context)
        {
            id = context.Id;
            name = context.Name;
            description = context.Description;
            BankNumber = context.BankNumber;
            Buyers = context.Buyers.Select(it => new BuyersModel(it)).ToArray();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int BankNumber { get; set; }
        public BuyersModel[] Buyers { get; set; }
    }
}
