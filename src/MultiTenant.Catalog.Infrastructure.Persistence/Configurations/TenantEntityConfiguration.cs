using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities;

namespace MultiTenant.Catalog.Infrastructure.Configurations
{
    public class TenantEntityConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenants");


            builder.Property(c => c.Name)
                .IsRequired();
            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.Property(c => c.Identifier)
                .IsRequired();
            builder.HasIndex(c => c.Identifier)
                .IsUnique();

            builder.HasOne(c => c.Resource)
                .WithMany(c => c.Tenants)
                .HasForeignKey(c => c.ResourceId)
                .IsRequired();

            builder.Property(c => c.ConnectionString)
                .IsRequired();
            builder.HasIndex(c => c.ConnectionString)
                .IsUnique();
        }
    }
}
