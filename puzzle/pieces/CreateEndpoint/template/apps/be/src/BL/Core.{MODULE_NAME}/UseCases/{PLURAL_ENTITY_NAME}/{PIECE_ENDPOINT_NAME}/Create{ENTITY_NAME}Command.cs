using Core.Admin.UseCases.Examples.Detail;
using MediatR;

namespace Core.Admin.UseCases.Examples.Create;

public record CreateExampleCommand(CreateExampleDto Data) : IRequest<ExampleDetailDto>;
