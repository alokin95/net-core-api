using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => new {l.City, l.Address });
            builder.Property(l => l.Address).IsRequired();
            builder.Property(l => l.City).IsRequired();
            builder.Property(l => l.Country).IsRequired();
            builder.Property(l => l.PostalCode).IsRequired();
        }
    }
}
