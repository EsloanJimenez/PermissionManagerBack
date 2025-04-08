using PermissionManager.Domain.Core;
using PermissionManager.Domain.Entity;
using PermissionManager.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace PermissionManager.Infrastructure.Context
{
    public class AppPermissionContext : DbContext
    {
        public AppPermissionContext(DbContextOptions<AppPermissionContext> op) : base(op)
        {
            
        }

        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());

            foreach(var entityType in modelBuilder.Model.GetEntityTypes().Where(b => typeof(BaseAuditory).IsAssignableFrom(b.ClrType)))
            {
                var configType = typeof(BaseAuditoriConfiguration<>).MakeGenericType(entityType.ClrType);
                var configInstance = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration((dynamic)configInstance);
            }
        }

    }
}
