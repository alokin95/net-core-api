using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).IsRequired();
        }
    }
}
