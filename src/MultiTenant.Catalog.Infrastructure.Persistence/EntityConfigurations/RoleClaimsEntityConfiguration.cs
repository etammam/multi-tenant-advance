using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities.Users;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations
{
    public class RoleClaimsEntityConfiguration : IEntityTypeConfiguration<RoleClaims>
    {
        public void Configure(EntityTypeBuilder<RoleClaims> builder)
        {
            builder.ToTable("RoleClaims");
        }
    }
}
