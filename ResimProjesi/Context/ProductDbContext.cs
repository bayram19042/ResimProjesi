using Microsoft.EntityFrameworkCore;
using ResimProjesi.Configurations;
using ResimProjesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResimProjesi.Models;

namespace ResimProjesi.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<ResimProjesi.Models.AddProduct> AddProduct { get; set; }

    }
}
