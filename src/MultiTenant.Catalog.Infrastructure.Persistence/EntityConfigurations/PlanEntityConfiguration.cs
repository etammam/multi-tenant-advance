using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations;

public class PlanEntityConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");

        builder.Property(c => c.Name)
            .IsRequired();
        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasMany(c => c.Subscriptions)
            .WithOne(c => c.Plan)
            .HasForeignKey(c => c.PlanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}