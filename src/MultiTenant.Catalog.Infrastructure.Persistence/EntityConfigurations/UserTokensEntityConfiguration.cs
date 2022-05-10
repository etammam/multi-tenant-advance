using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities.Users;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations
{
    public class UserTokensEntityConfiguration : IEntityTypeConfiguration<UserTokens>
    {
        public void Configure(EntityTypeBuilder<UserTokens> builder)
        {
            builder.ToTable("UserTokens");
        }
    }
}
