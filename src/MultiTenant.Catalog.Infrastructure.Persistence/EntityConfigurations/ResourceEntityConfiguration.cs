using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations
{
    public class ResourceEntityConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.ServerAddress)
                .IsRequired();

            builder.Property(c => c.ServerPort)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.ServerUserName)
                .IsRequired();

            builder.Property(c => c.ServerPassword)
                .IsRequired();

            builder.Property(c => c.DatabaseProvider)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.Capacity)
                .HasDefaultValue(1);
        }
    }
}
