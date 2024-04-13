using FinanceAPI.Managers;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Context
{
    public class ApplicationContext
    {

        public ApplicationContext(IConfiguration config)
        {
            Version = "0.1";
            Title = "help";
            Configuration = config;
            Initialize();
        }

        public void Initialize()
        {

            /*Инициализация менеджеров*/
            SellerManager = new SellersManager(this);
            BuyersManager = new BuyersManager(this);

            SellerManager.Read();
            BuyersManager.Read();

        }

        public SellersManager SellerManager { get; set; }
        public BuyersManager BuyersManager { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public IConfiguration Configuration { get; set; }

        /*Здесь указать название подключения из appsettings*/
        public DBContext CreateDbContext() => new DBContext(Configuration.GetConnectionString("DefaultConnection"));

    }
}
