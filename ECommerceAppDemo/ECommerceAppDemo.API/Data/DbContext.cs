using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ECommerceAppDemo.API.Models;

namespace ECommerceAppDemo.API.Data
{
    public class ECommerceDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public ECommerceDbContext() : base("name=ECommerceDbContext") { }

      //  public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

      



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product_New");
            modelBuilder.Entity<Order>().ToTable("Orders");
        }
    }

}