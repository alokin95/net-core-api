using DataAccess.Configurations;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<EntityBase>().HasQueryFilter(eb => eb.DeletedAt == null);
        }

        public override int SaveChanges()
        {
            this.SetDefaultValues();

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=reservation;Integrated Security=True");
        }


        private void SetDefaultValues()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is EntityBase e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.isActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.DeletedAt = null;
                            e.UpdatedAt = null;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}
