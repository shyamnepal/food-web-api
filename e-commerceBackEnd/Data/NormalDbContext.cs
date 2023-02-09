using e_commerceBackEnd.Model;
using e_commerceBackEnd.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace e_commerceBackEnd.Data
{
    public class NormalDbContext : DbContext
    {
        public NormalDbContext(DbContextOptions<NormalDbContext> options) : base(options)

        {

        }

        public DbSet<ProductDto> tbl_products { get; set; }

        public DbSet<Customer> tbl_Customer { get; set; }
        public DbSet<Order> tbl_Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Payment> tbl_Payment { get; set; }
        public DbSet<FoodItem> tbl_FoodItem { get; set;}
        public DbSet<Menu> tbl_Menu { get; set; }
    }

   
}
