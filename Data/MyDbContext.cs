using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using api.Entities.Concrete;
using api.Entities.Abstract;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;


namespace api.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderItem> OrderDetails { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
       

        public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    =>
        optionsBuilder.UseNpgsql("Host=localhost;Database=Retail;Username=postgres;Password=1234"
);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<ShopCart>()
                .HasMany(sc => sc.CartItems)
                .WithOne(ci => ci.ShopCart)
                .HasForeignKey(ci => ci.ShopCartId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);
                modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)  
                .WithMany(c => c.Products) 
                .HasForeignKey(p => p.CategoryId); 

        }
    }
}