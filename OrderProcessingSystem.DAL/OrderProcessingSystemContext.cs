using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.DAL
{
    public class OrderProcessingSystemContext : IdentityDbContext<IdentityUser>
    {
        public OrderProcessingSystemContext(DbContextOptions<OrderProcessingSystemContext> options) : base(options) { }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Orders>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.CustomerName);
                entity.Property(o => o.OrderDetails);
                entity.Property(o => o.AmountDue);
            });
        }
    }
}