using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Entities.Users;
using MultiTenant.Catalog.Domain.Enums;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        var hasher = new PasswordHasher<User?>();
        var user = new User
        {
            Id = Guid.Parse("79349908-ee08-4b2f-b1dd-f8bd35b92753"),
            PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
            SecurityStamp = string.Empty
        };
        user.SetName("Administrator");
        user.SetUsername("admin");
        user.SetEmail("admin@tenant-catalog.com");
        user.SetPhoneNumber("+2 01100072682");
        user.SetGender(Gender.Other);
        user.SetEmailConfirmation(true);

        builder.HasData(new List<User>
        {
            user
        });
    }
}