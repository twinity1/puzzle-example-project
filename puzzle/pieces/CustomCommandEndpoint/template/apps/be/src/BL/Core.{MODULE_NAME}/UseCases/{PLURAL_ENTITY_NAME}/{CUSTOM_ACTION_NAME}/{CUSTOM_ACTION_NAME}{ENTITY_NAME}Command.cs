using MediatR;

namespace Core.Admin.UseCases.Examples.Detail;

public record CreateExampleCommand(Guid Id) : IRequest<ExampleDetailDto>;
