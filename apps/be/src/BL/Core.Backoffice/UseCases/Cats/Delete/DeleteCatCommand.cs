using MediatR;

namespace Core.Backoffice.UseCases.Cats.Delete;

public record DeleteCatCommand(Guid Id) : IRequest;
