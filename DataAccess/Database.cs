using Domain.Entity;
using EFDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Chain> Chains { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AmenityConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ChainConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomAmenityConfiguration());
            modelBuilder.ApplyConfiguration(new HotelAmenityConfiguration());

            modelBuilder.Entity<Hotel>().HasQueryFilter(h => h.isActive && h.DeletedAt == null);
            modelBuilder.Entity<Location>().HasQueryFilter(l => l.Hotel.isActive && l.Hotel.DeletedAt == null);
            modelBuilder.Entity<Chain>().HasQueryFilter(c => c.isActive && c.DeletedAt == null);
            modelBuilder.Entity<Amenity>().HasQueryFilter(a => a.isActive && a.DeletedAt == null);
            modelBuilder.Entity<Room>().HasQueryFilter(r => r.isActive && r.DeletedAt == null);
            modelBuilder.Entity<User>().HasQueryFilter(u => u.isActive && u.DeletedAt == null);
        }

        public override int SaveChanges()
        {
            this.SetDefaultValues();

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=booking_latest;Integrated Security=True");
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
