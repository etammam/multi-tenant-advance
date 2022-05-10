using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using MultiTenant.Catalog.Core.Common;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;
using MultiTenant.Catalog.Domain.Entities.Users;
using MultiTenant.Catalog.Domain.Exceptions;
using System.Security.Claims;
using NotFoundException = MultiTenant.Catalog.Domain.Exceptions.NotFoundException;

namespace MultiTenant.Catalog.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IDateTimeService _dateTimeService;
    private readonly ISerializerService _serializerService;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;

    public AccountService(UserManager<User> userManager,
        SignInManager<User> signInManager,
        ITokenService tokenService, IDateTimeService dateTimeService, ISerializerService serializerService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _dateTimeService = dateTimeService;
        _serializerService = serializerService;
    }

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        Guard.Against.NullOrEmpty(email, nameof(email));
        Guard.Against.NullOrEmpty(password, nameof(password));

        var userAccount = await _userManager.FindByEmailAsync(email);
        if (userAccount == null)
            throw new NotFoundException(nameof(email), nameof(userAccount));
        var signInResult = await _signInManager.PasswordSignInAsync(userAccount.UserName, password, false, false);
        if (signInResult.Succeeded == false)
            throw new UnableToSignException(userAccount.Email);
        var userRoles = await _userManager.GetRolesAsync(userAccount);
        var authenticationResult = await _tokenService.GenerateTokenAsync(userAccount,
            GenerateUserClaims(userAccount, userRoles.ToList()),
            _dateTimeService.Now().AddDays(2));
        userAccount.SetLastLogin(_dateTimeService.Now());
        await _userManager.UpdateAsync(userAccount);


        return authenticationResult;
    }

    private Claim[] GenerateUserClaims(User user, List<string> roles)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,
                string.IsNullOrEmpty(user.Id.ToString()) ? string.Empty : user.Id.ToString()),
            new Claim(ClaimTypes.GivenName, string.IsNullOrEmpty(user.UserName) ? string.Empty : user.UserName),
            new Claim(ClaimTypes.Name, string.IsNullOrEmpty(user.Name) ? string.Empty : user.Name),
            new Claim(ClaimTypes.Email, string.IsNullOrEmpty(user.Email) ? string.Empty : user.Email),
            new Claim(ClaimTypes.MobilePhone, string.IsNullOrEmpty(user.PhoneNumber) ? string.Empty : user.PhoneNumber),
            new Claim("avatarUrl", string.IsNullOrEmpty(user.AvatarUrl) ? string.Empty : user.AvatarUrl),
            new Claim("IsMobileConfirmed", user.PhoneNumberConfirmed.ToString()),
            new Claim("IsEmailConfirmed", user.EmailConfirmed.ToString()),
            new Claim(ClaimTypes.Role, _serializerService.Serialize(roles))
        };
        return claims;
    }
}