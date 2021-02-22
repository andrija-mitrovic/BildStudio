using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DevicePropertyValue> DevicePropertyValues { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DeviceTypeProperty> DeviceTypeProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<DeviceType>(entity =>
            //{
            //    entity
            //        .HasMany(e => e.Children)
            //        .WithOne(e => e.Parent)
            //        .HasForeignKey(e => e.ParentId)
            //        .OnDelete(DeleteBehavior.NoAction); 
            //});
        }
    }
}
