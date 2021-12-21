using ECommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DataAcces
{
    public class ECommerceDbConext : DbContext
    {
        public ECommerceDbConext()
        {

        }
        public ECommerceDbConext(DbContextOptions<ECommerceDbConext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property<decimal>(p => p.UnitPrice)
                .HasPrecision(8, 2);
        }
        public DbSet<Category> Categories{get;set; }
        public DbSet<Product> Products { get; set; }


    }
}
