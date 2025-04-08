using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManager.Domain.Entity;

namespace PermissionManager.Infrastructure.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.PermissionId);

            builder.Property(p => p.PermissionId).ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.PermissionDate)
                .IsRequired();

            builder.HasOne(p => p.PermissionTypeNav)
                .WithMany(p => p.Permissions)
                .HasForeignKey(p => p.PermissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permissio__Delet__412EB0B6");
        }
    }
}
