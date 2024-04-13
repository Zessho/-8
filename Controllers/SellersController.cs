using FinanceAPI.Context;
using FinanceAPI.Controllers.DTO;
using FinanceAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAPI.Controllers
{
    public class SellersController:BaseController
    {
        public SellersController(ApplicationContext _appContext):base(_appContext) { }

        [HttpGet("[controller]/[action]")]
        public JsonResult Init()
        {
            var res = GetCommon();
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetAll()
        {
            var res = GetCommon();
            res.Seller = ApplicationContext.SellerManager.Sellers.Select(it => new SellerModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.Sellers = new SellerModel(ApplicationContext.SellerManager.Sellers.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] SellerModel model)
        {
            Seller Seller = ApplicationContext.SellerManager.Create(model);

            var res = GetCommon();
            res.Sellers = new SellerModel(Seller);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] SellerModel model)
        {

            Seller Seller = ApplicationContext.SellerManager.Update(model);

            var res = GetCommon();
            res.Seller = new SellerModel(Seller);
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetBuyers(int SellerId)
        {

            Buyers[] Buyers = ApplicationContext.SellerManager.GetBuyers(SellerId);

            var res = GetCommon();
            res.Buyers = Buyers.Select(it => new BuyersModel(it));
            return Send(true, res);
        }
        [HttpPost("[controller]/[action]")]
        public JsonResult AttachBuyer(int SellerId, int BuyerId)
        {

            Buyers[] Buyers = ApplicationContext.SellerManager.AttachBuyer(SellerId, BuyerId);

            var res = GetCommon();
            res.Buyers = Buyers.Select(it => new BuyersModel(it));
            return Send(true, res);
        }
        [HttpPost("[controller]/[action]")]
        public JsonResult DettachBuyers(int SellerId, int BuyerId)
        {

            Buyers[] Buyer = ApplicationContext.SellerManager.DettachBuyers(SellerId, BuyerId);

            var res = GetCommon();
            res.Buyers = Buyer.Select(it => new BuyersModel(it));
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.SellerManager.Delete(id);
            var res = GetCommon();
            res.Sellers = ApplicationContext.SellerManager.Sellers.Select(it => new SellerModel(it));
            return Send(true, res);
        }
    }
}
