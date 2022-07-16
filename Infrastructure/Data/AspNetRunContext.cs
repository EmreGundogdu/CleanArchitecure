using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AspNetRunContext : DbContext
    {
        public AspNetRunContext(DbContextOptions<AspNetRunContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(ConfigureProduct);
            modelBuilder.Entity<Category>(ConfigureCategory);
        }
        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(ci => ci.Id);
            builder.Property(X => X.Id).IsRequired();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
        }
        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(ci => ci.Id);
            builder.Property(X => X.Id).IsRequired();
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
        }
    }
}
