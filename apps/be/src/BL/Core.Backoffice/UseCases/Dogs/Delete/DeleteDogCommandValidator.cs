using FluentValidation;

namespace Core.Backoffice.UseCases.Dogs.Delete;

public class DeleteDogCommandValidator : AbstractValidator<DeleteDogCommand>
{
    public DeleteDogCommandValidator()
    {
        // Add validation rules here if needed
    }
}
