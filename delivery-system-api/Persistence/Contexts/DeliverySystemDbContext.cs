using delivery_system_api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace delivery_system_api.Persistence.Contexts
{
    public class DeliverySystemDbContext:DbContext
    {
        public DeliverySystemDbContext(DbContextOptions<DeliverySystemDbContext>options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    //    modelBuilder.Entity<OrderProductItem>().HasOne<Product>(op=>op.Product).WithMany(p=>p.OrderProductItems).HasForeignKey<OrderProductItem>(op=>op.ProductId)
        modelBuilder.Entity<OrderProductItem>()
                .HasOne<Order>(op=>op.Order)
                .WithMany(o=>o.Products)
                .HasForeignKey(op=>op.OrderId);

        modelBuilder.Entity<OrderAddress>()
                .HasOne<Order>(oa => oa.Order)
                .WithOne(o => o.OrderAddress)
                .HasForeignKey<OrderAddress>(oa => oa.OrderId);
  
        }
       public DbSet<User> users { get; set; } 
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Viechle> viechles { get; set; } 
        public DbSet<OrderProductItem> OrderProductItems { get; set; } 
        public DbSet<OrderAddress> OrderAddresses { get; set; } 
        public DbSet<Order> Orders { get; set; }    
    }
}
