using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResimProjesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResimProjesi.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(80);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(150);
            builder.Property(x => x.Price).IsRequired(true).HasColumnType("decimal(18,2)");
            builder.HasMany(x => x.Pictures).WithOne(x => x.product).HasForeignKey(x => x.ProductId);
        }
    }
}
