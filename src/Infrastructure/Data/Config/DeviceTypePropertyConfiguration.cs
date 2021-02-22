using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DeviceTypePropertyConfiguration : IEntityTypeConfiguration<DeviceTypeProperty>
    {
        public void Configure(EntityTypeBuilder<DeviceTypeProperty> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(255);

            builder.HasOne(c => c.DeviceType)
               .WithMany(c => c.DeviceTypeProperties)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
