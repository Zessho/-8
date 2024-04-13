using FinanceAPI.Models;

namespace FinanceAPI.Replicates
{
    public class Buyers
    {

        public EFBuyer Context { get; set; }
        public Buyers(EFBuyer context) { Context = context; }

        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }
        public int BankNumber { get => Context.BankNumber; set => Context.BankNumber = value; }

        public List<Seller> Sellers { get => Context.Sellers.Select(it => new Seller(it)).ToList(); }
    }
}
