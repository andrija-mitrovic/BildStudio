using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DevicePropertyValueConfiguration : IEntityTypeConfiguration<DevicePropertyValue>
    {
        public void Configure(EntityTypeBuilder<DevicePropertyValue> builder)
        {
            builder.HasOne(e => e.Device)
                   .WithMany(e => e.DevicePropertyValues)
                   .HasForeignKey(e => e.DeviceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
