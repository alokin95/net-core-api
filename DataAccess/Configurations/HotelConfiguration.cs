﻿using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EFDataAccess.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasIndex(h => h.Name).IsUnique();
            builder.Property(h => h.Description).HasMaxLength(200);

            builder.HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Manager)
                .WithMany(u => u.Hotels)
                .HasForeignKey(h => h.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.Amenities)
                .WithOne(ha => ha.Hotel)
                .HasForeignKey(h => h.HotelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
