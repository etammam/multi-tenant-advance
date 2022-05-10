using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities.Users;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations
{
    public class UserLoginsEntityConfiguration : IEntityTypeConfiguration<UserLogins>
    {
        public void Configure(EntityTypeBuilder<UserLogins> builder)
        {
            builder.ToTable("UserLogins");
        }
    }
}
