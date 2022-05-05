using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations;

public class BusinessEntityConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.ToTable("Business");

        builder.Property(c => c.Name)
            .IsRequired();
        builder.HasIndex(c => c.Name)
            .IsUnique();


        builder.HasMany<Organization>()
            .WithOne(c => c.Business)
            .HasForeignKey(c => c.BusinessId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}