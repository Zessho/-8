using FinanceAPI.Context;
using FinanceAPI.Controllers.DTO;
using FinanceAPI.Models;
using FinanceAPI.Replicates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinanceAPI.Managers
{
    public class BuyersManager
    {

        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public BuyersManager(ApplicationContext applicationContext) { ApplicationContext = applicationContext; DBContext = applicationContext.CreateDbContext(); }

        private List<Buyers> _Buyers { get; set; } = new List<Buyers>();

        public Buyers[] Buyers { get => _Buyers.ToArray(); }
        public bool Read()
        {
            try
            {

                DBContext.Buyers.Include(it => it.Sellers).ToList();
                foreach (EFBuyer item in DBContext.Buyers)
                {
                    if (item.IsDeleted != true) _Buyers.Add(new Buyers(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Buyers Get(int id) => _Buyers.FirstOrDefault(it => it.Id == id);

        public Buyers Create(BuyersModel model)
        {
            try
            {
                EFBuyer Buyers = new EFBuyer()
                {
                    Name = model.name,
                   
                    BankNumber = model.BankNumber,
                };
                DBContext.Add(Buyers);
                DBContext.SaveChanges();

                Buyers replicate = new Buyers(Buyers);
                _Buyers.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Buyers Update(BuyersModel model)
        {
            try
            {

                EFBuyer _Buyer = DBContext.Buyers.FirstOrDefault(it => it.Id == model.id);


                _Buyer.Name = model.name;
                _Buyer.BankNumber = model.BankNumber;
                

                DBContext.Update(_Buyer);

                _Buyers.Remove(_Buyers.FirstOrDefault(it => it.Id == model.id));
                Buyers repl = new Buyers(_Buyer);
                _Buyers.Add(repl);

                return repl;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFBuyer _Buyer = DBContext.Buyers.FirstOrDefault(it => it.Id == id);
                _Buyer.IsDeleted = true;
                DBContext.Update(_Buyers);

                _Buyers.Remove(_Buyers.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
