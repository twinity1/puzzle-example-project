using MediatR;

namespace Core.Admin.UseCases.Examples.Detail;

public record GetExampleDetailQuery(Guid Id) : IRequest<ExampleDetailDto>;
