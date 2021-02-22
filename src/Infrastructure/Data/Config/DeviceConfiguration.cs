using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(255);

            builder.HasOne(c => c.DeviceType)
                   .WithMany(c => c.Devices)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
