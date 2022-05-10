using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities.Users;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations
{
    public class UserClaimsEntityConfiguration : IEntityTypeConfiguration<UserClaims>
    {
        public void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            builder.ToTable("UserClaims");
        }
    }
}
