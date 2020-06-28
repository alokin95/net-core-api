using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(200);

            builder.HasMany(r => r.Amenities)
                .WithOne(ra => ra.Room)
                .HasForeignKey(ra => ra.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
