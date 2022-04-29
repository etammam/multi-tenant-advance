using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations
{
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscriptions");

            builder.HasOne(c => c.Plan)
                .WithMany(c => c.Subscriptions)
                .HasForeignKey(c => c.PlanId)
                .IsRequired();

            builder.HasOne(c => c.Organization)
                .WithMany(c => c.Subscriptions)
                .HasForeignKey(c => c.OrganizationId)
                .IsRequired();
        }
    }
}
