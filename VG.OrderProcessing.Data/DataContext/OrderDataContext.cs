using Microsoft.EntityFrameworkCore;
using VG.OrderProcessing.Model;

namespace VG.OrderProcessing.Data
{
    public class OrderDataContext : DbContext
    {
        #region Fields/Properties
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        #endregion

        #region Constructor
        public OrderDataContext(DbContextOptions<OrderDataContext> options) : base(options)
        { }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<OrderDetail>().ToTable("OrderDetail");
        }
        #endregion

    }
}
