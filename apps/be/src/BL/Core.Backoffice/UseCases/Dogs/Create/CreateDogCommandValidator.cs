using FluentValidation;

namespace Core.Backoffice.UseCases.Dogs.Create;

public class CreateDogCommandValidator : AbstractValidator<CreateDogCommand>
{
    public CreateDogCommandValidator()
    {
        RuleFor(x => x.Data.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Data.Age).GreaterThan(0).WithMessage("Age must be greater than 0.");
    }
}
