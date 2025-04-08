using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManager.Domain.Core;

namespace PermissionManager.Infrastructure.Configuration
{
    public class BaseAuditoriConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseAuditory
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(ba => ba.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.ModifyDate)
                .IsRequired(false);

            builder.Property(ba => ba.DeletedDate)
                .IsRequired(false);

            builder.Property(ba => ba.Deleted);
        }
    }
}
