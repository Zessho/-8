using FinanceAPI.Context;
using FinanceAPI.Controllers.DTO;
using FinanceAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAPI.Controllers
{
    public class BuyersController:BaseController
    {
        public BuyersController(ApplicationContext _appContext):base(_appContext) { }


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
            res.Buyer = ApplicationContext.BuyersManager.Buyers.Select(it => new BuyersModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.tables = new BuyersModel (ApplicationContext.BuyersManager.Buyers.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] BuyersModel model)
        {
            Buyers Seller = ApplicationContext.BuyersManager.Create(model);

            var res = GetCommon();
            res.tables = new BuyersModel(Seller);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] BuyersModel model)
        {

            Buyers Seller = ApplicationContext.BuyersManager.Update(model);

            var res = GetCommon();
            res.tables = new BuyersModel(Seller);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.BuyersManager.Delete(id);
            var res = GetCommon();
            res.tables = ApplicationContext.BuyersManager.Buyers.Select(it => new BuyersModel(it));
            return Send(true, res);
        }
    }
}
