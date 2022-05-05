using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities;
using MultiTenant.Catalog.Domain.ValueObjects;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations;

public class OrganizationEntityConfiguration :
    IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();
        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasIndex(c => c.VatNumber)
            .IsUnique();

        builder.HasOne(c => c.Tenant)
            .WithOne(c => c.Organization)
            .HasForeignKey<Tenant>(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(c => c.Contact);
        builder.Ignore(c => c.Address);

        builder.OwnsOne<Contact>(c => c.Contact);

        builder.OwnsMany<Address>(c => c.Address, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("OrganizationId");
            navigationBuilder.Property<int>("Id");
            navigationBuilder.HasKey("Id");
        });
    }
}