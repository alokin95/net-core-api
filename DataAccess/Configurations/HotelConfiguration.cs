using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasIndex(h => h.Name).IsUnique();
            builder.Property(h => h.Description).HasMaxLength(200);

            builder.HasOne(h => h.Chain)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.ChainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Manager)
                .WithMany(u => u.Hotels)
                .HasForeignKey(h => h.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
