using System.Data;
using System.Data.Common;
using ItemShop.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ItemShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionStings;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionStings = _configuration.GetConnectionString("DefaultConnection");
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ItemShopDiscount;User=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public DbConnection CreateConnection() => new SqlConnection(_connectionStings);


    }
}