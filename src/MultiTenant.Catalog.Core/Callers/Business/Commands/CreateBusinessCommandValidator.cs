using FluentValidation;

namespace MultiTenant.Catalog.Core.Callers.Business.Commands;

public class CreateBusinessCommandValidator : AbstractValidator<CreateBusinessCommand>
{
    public CreateBusinessCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .Length(2, int.MaxValue);
    }
}