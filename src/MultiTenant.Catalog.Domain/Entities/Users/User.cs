using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Domain.Enums;
using MultiTenant.Catalog.Domain.Exceptions;

namespace MultiTenant.Catalog.Domain.Entities.Users;

public sealed class User : IdentityUser<Guid>, IAggregateRoot, IBaseEntity
{
    public User()
    {
    }

    public User(string name, string email, Gender gender, string username, string phoneNumber
        , DateTime dateOfBirth)
        : this(Guid.NewGuid(), name, email, gender, username, phoneNumber, dateOfBirth)
    {
    }

    public User(Guid userId, string name, string email, Gender gender, string username, string phoneNumber)
    {
        Id = userId;
        SetEmail(email);
        SetName(name);
        SetGender(gender);
        SetUsername(username);
        SetPhoneNumber(phoneNumber);
    }

    public User(Guid userId, string name, string email, Gender gender, string username, string phoneNumber,
        DateTime dateOfBirth)
        : this(userId, name, email, gender, username, phoneNumber)
    {
        SetDateOfBirth(dateOfBirth);
    }

    public string AvatarUrl { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public string Name { get; private set; }
    public DateTime LastLogin { get; set; }

    public void SetAvatarUrl(string avatarUrl)
    {
        AvatarUrl = Guard.Against.NotUrl(avatarUrl, nameof(avatarUrl));
    }

    public void SetDateOfBirth(DateTime dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
    }

    public void SetGender(Gender gender)
    {
        Gender = gender;
    }

    public void SetUsername(string username)
    {
        Guard.Against.NullOrEmpty(username, nameof(username));
        UserName = username.ToLower().Replace(" ", string.Empty);
        NormalizedUserName = username.ToUpper().Replace(" ", string.Empty);
    }

    public void SetEmail(string email)
    {
        Email = Guard.Against.NotEmailAddress(email, nameof(email));
        NormalizedEmail = Guard.Against.NotEmailAddress(email, nameof(email)).ToUpper();
    }

    public void SetEmailConfirmation(bool confirmed)
    {
        EmailConfirmed = confirmed;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));
    }

    public void SetPhoneNumberConfirmation(bool confirmed)
    {
        PhoneNumberConfirmed = confirmed;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetLastLogin(DateTime lastLogin)
    {
        LastLogin = lastLogin;
    }
}