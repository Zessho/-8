using FinanceAPI.Context;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace FinanceAPI.Controllers
{
    public class BaseController: Controller
    {
        public ApplicationContext ApplicationContext { get; set; }

        public BaseController(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        internal dynamic GetCommon() => new ExpandoObject();
        internal JsonResult Send(bool status, object data)
        {
            return new JsonResult(
                new
                {
                    status,
                    data,
                    datetime = DateTime.Now.ToString()
                });
        }
    }
}
