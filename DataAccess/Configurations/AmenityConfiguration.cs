using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.Name).HasMaxLength(100);

            builder.HasMany(a => a.Rooms)
                .WithOne(ra => ra.Amenity)
                .HasForeignKey(ra => ra.AmenityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.Hotels)
                .WithOne(ha => ha.Amenity)
                .HasForeignKey(ha => ha.AmenityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
