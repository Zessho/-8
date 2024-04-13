using FinanceAPI.Models;

namespace FinanceAPI.Replicates
{
    public class Seller
    {
        private EFSeller Context { get; set; }
        public Seller(EFSeller context) { Context = context; }
        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }

        public string Description { get => Context.Description; set => Context.Description = value; }
        public int BankNumber { get => Context.BankNumber; set => Context.BankNumber = value; }

        public List<Buyers> Buyers{  get => Context.EFBuyers.Select(it => new Buyers(it)).ToList();
        }
    }
}
