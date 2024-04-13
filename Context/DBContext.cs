using FinanceAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace FinanceAPI.Context
{
    public class DBContext : DbContext
    {

        /*Перечисление моделей*/
        public DbSet<EFSeller> Sellers { get; set; }
        public DbSet<EFBuyer> Buyers { get; set; }
        public DBContext(string cnnString)
        {
            ConnectionString = cnnString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            /*Если используете другие БД*/
            /*optionsBuilder.UseNpgsql(ConnectionString);
            optionsBuilder.UseMySQL(ConnectionString);*/
        }
    }
}
