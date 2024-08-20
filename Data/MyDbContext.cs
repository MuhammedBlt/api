using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;


namespace api.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    =>
        optionsBuilder.UseNpgsql("Host=localhost;Database=Retail;Username=postgres;Password=1234"
);
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.Product)
            .WithMany(o => o.Orders).HasForeignKey(o => o.ProductId);
        }
    }
}