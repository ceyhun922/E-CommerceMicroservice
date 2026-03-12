using ItemShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemShop.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ItemShopOrder;User=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;");
        }

        public DbSet<Address> Addresses {get;set;}
        public DbSet<OrderDetail> OrderDetails {get;set;}
        public DbSet<Ordering> Orderings {get;set;}
    }
}