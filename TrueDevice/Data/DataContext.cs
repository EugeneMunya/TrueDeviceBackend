using Microsoft.EntityFrameworkCore;
using TrueDevice.Models;

namespace TrueDevice.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { 

        }
         public DbSet<Device> Devices{get;set;}
         public DbSet<User> Users{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(user => user.Role).HasDefaultValue("User");
            modelBuilder.Entity<User>().HasIndex(user => user.IdNumber).IsUnique();
            modelBuilder.Entity<Device>().HasIndex(device => device.SerialNumber).IsUnique();
            modelBuilder.Entity<Device>().HasIndex(device => device.MackAddress).IsUnique();
            modelBuilder.Entity<Device>().HasIndex(device => device.Imei).IsUnique();
        }
    }
}