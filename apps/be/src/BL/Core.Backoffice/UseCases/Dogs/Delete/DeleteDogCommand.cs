using MediatR;

namespace Core.Backoffice.UseCases.Dogs.Delete;

public record DeleteDogCommand(Guid Id) : IRequest;
