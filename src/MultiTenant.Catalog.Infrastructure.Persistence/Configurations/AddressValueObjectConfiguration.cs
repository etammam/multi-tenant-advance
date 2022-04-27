using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.ValueObjects;

namespace MultiTenant.Catalog.Infrastructure.Configurations
{
    public class AddressValueObjectConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.Property<int>("Id")
                .IsRequired();
            builder.HasKey("Id");
        }
    }
}
