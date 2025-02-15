using MediatR;

namespace Core.Admin.UseCases.Examples.Delete;

public record DeleteExampleCommand(Guid Id) : IRequest;
