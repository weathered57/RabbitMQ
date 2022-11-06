using Microsoft.EntityFrameworkCore;
using RabbitMQ.Entities;

namespace RabbitMQ.DataAccess.Concrete.EntityFramework.Context
{
    public class RabbitMqShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Server=VTITUL14748\\SQLEXPRESS;Database=RabbitMqShop;Trusted_Connection=True;");
        }
       

        public DbSet<Products> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
