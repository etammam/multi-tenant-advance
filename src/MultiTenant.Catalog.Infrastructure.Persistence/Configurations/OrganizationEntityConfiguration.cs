using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities;
using MultiTenant.Catalog.Domain.ValueObjects;

namespace MultiTenant.Catalog.Infrastructure.Configurations;

public class OrganizationEntityConfiguration :
    IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations");

        builder.Property(c => c.Name)
            .IsRequired();
        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasIndex(c => c.VatNumber)
            .IsUnique();

        builder.HasOne(c => c.Tenant)
            .WithOne(c => c.Organization)
            .IsRequired()
            .HasForeignKey<Tenant>(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne<Contact>(c => c.Contact);

        builder.OwnsOne<Address>(c => c.Address);

    }
}