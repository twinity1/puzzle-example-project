using FluentValidation;

namespace Core.Backoffice.UseCases.Cats.Delete;

public class DeleteCatCommandValidator : AbstractValidator<DeleteCatCommand>
{
    public DeleteCatCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
