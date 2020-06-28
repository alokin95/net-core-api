using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ChainConfiguration : IEntityTypeConfiguration<Chain>
    {
        public void Configure(EntityTypeBuilder<Chain> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.HasOne(c => c.Manager)
                .WithMany(m => m.Chains)
                .HasForeignKey(c => c.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
