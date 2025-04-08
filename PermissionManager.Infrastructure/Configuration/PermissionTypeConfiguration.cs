using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManager.Domain.Entity;

namespace PermissionManager.Infrastructure.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(pt => pt.PermissionTypeId);

            builder.Property(pt => pt.PermissionTypeId).ValueGeneratedOnAdd();

            builder.Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
