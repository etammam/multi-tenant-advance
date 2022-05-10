using FluentValidation;

namespace MultiTenant.Catalog.Core.Callers.Account.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.Email)
            .EmailAddress()
            .NotNull()
            .NotEmpty();

        RuleFor(c => c.Password)
            .NotNull()
            .NotEmpty();
    }
}