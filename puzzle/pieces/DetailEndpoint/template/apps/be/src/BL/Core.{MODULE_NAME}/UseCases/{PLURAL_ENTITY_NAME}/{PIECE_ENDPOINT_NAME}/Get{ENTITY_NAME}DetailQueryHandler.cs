using Core.Data.Context;
using Modules.Abstraction.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Admin.UseCases.Examples.Detail;

public class GetExampleDetailQueryHandler(ICoreDataContext context)
    : IRequestHandler<GetExampleDetailQuery, ExampleDetailDto>
{
    public async Task<ExampleDetailDto> Handle(GetExampleDetailQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await context
            .Examples
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException($"Entity with {request.Id} was not found");
        }

        return entity.ToDetailDto();
    }
}
