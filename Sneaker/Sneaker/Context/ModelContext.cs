using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Sneaker.ViewModel;

namespace Sneaker.Context
{
    public class ModelContext : DbContext
    {
        public DbSet<Models.Sneaker> Sneakers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Img> Imgs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSize>()
                .HasKey(t => new
                {
                    t.ProductId,
                    t.SizeId
                });
            modelBuilder.Entity<ProductSize>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.SneakerSizes)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductSize>()
                .HasOne(pt => pt.Size)
                .WithMany(p => p.SneakerSizes)
                .HasForeignKey(pt => pt.SizeId);
        }
    }
}
