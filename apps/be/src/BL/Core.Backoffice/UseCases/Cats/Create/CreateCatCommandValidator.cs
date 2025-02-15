using Core.Backoffice.UseCases.Cats.Create;
using FluentValidation;

namespace Core.Backoffice.UseCases.Cats.Create;

public class CreateCatCommandValidator : AbstractValidator<CreateCatCommand>
{
    public CreateCatCommandValidator()
    {
        RuleFor(x => x.Data.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Data.Age)
            .GreaterThanOrEqualTo(0);
    }
}
