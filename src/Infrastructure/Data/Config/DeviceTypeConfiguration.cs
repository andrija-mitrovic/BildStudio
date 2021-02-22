using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DeviceTypeConfiguration : IEntityTypeConfiguration<DeviceType>
    {
        public void Configure(EntityTypeBuilder<DeviceType> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(255);

            builder.HasMany(e => e.Children)
                   .WithOne(e => e.Parent)
                   .HasForeignKey(e => e.ParentId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
