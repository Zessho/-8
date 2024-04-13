using FinanceAPI.Context;
using FinanceAPI.Controllers.DTO;
using FinanceAPI.Models;
using FinanceAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Managers
{
    public class SellersManager
    {

        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public SellersManager (ApplicationContext applicationContext) { ApplicationContext = applicationContext;  DBContext = applicationContext.CreateDbContext(); }

        private List<Seller> _Sellers { get; set; } = new List<Seller> ();

        public Seller[] Sellers { get => _Sellers.ToArray (); }
        public bool Read()
        {
            try
            {
                DBContext.Sellers.Include(it => it.EFBuyers).ToList();
                foreach (EFSeller item in DBContext.Sellers)
                {
                    if(item.IsDeleted != true) _Sellers.Add(new Seller(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Seller Get(int id) => _Sellers.FirstOrDefault(it => it.Id == id);

        public Seller Create(SellerModel model)
        {
            try
            {
                EFSeller Seller = new EFSeller()
                {
                    Name = model.name,
                    Description = model.description,
                    BankNumber = model.BankNumber,
                };
                DBContext.Add(Seller);
                DBContext.SaveChanges();

                Seller replicate = new Seller(Seller);
                _Sellers.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Seller Update(SellerModel model)
        {
            try
            {

                EFSeller _Seller = DBContext.Sellers.FirstOrDefault(it => it.Id == model.id);


                _Seller.Name = model.name;
                _Seller.Description = model.description;
                _Seller.BankNumber = model.BankNumber;

                DBContext.Update(_Seller);
                DBContext.SaveChanges();

                _Sellers.Remove(_Sellers.FirstOrDefault(it => it.Id == model.id));
                Seller repl = new Seller(_Seller);
                _Sellers.Add(repl);

                return repl;
            }
            catch { throw; }
        }

        public Buyers[] GetBuyers(int SellerId)
        {
            return Get(SellerId).Buyers.ToArray();
        }

        public Buyers[] AttachBuyer(int SellerId, int BuyerId)
        {
            var table = ApplicationContext.BuyersManager.Get(BuyerId);

            var _Seller = DBContext.Sellers.FirstOrDefault(it => it.Id == SellerId);
            _Seller.EFBuyers.Add(table.Context);

            DBContext.Update(_Seller);
            DBContext.SaveChanges();

            var Seller = Get(SellerId);
            Seller.Buyers.Add(table);

            return GetBuyers(SellerId);
        }

        public Buyers[] DettachBuyers(int SellerId, int BuyerId)
        {
            var Buyer = ApplicationContext.BuyersManager.Get(BuyerId);

            var _Seller = DBContext.Sellers.FirstOrDefault(it => it.Id == SellerId);
            _Seller.EFBuyers.Remove(Buyer.Context);

            DBContext.Update(_Seller);
            DBContext.SaveChanges();


            var Seller = Get(SellerId);
            Seller.Buyers.Remove(Buyer);

            return GetBuyers(SellerId);
        }

        public bool Delete(int id)
        {
            try
            {

                EFSeller _Seller = DBContext.Sellers.FirstOrDefault(it => it.Id == id);
                _Seller.IsDeleted = true;
                DBContext.Update(_Seller);
                DBContext.SaveChanges();
                _Sellers.Remove(_Sellers.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }



        }

    }
}
