using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.ValueObjects;

namespace MultiTenant.Catalog.Infrastructure.Configurations
{
    public class ContactValueObjectConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.Property<int>("Id")
                .IsRequired();
            builder.HasKey("Id");
        }
    }
}
