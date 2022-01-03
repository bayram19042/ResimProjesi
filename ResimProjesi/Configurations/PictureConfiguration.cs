using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResimProjesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResimProjesi.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Pictures>
    {
      
        public void Configure(EntityTypeBuilder<Pictures> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName).IsRequired(true).HasMaxLength(200);
        }
    }
}
