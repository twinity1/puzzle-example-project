using Core.Data.Context;
using Modules.Abstraction.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Backoffice.UseCases.Cats.Detail;

public class GetCatDetailQueryHandler(ICoreDataContext context)
    : IRequestHandler<GetCatDetailQuery, CatDetailDto>
{
    public async Task<CatDetailDto> Handle(GetCatDetailQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await context
            .Cats
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException($"Entity with {request.Id} was not found");
        }

        return entity.ToDetailDto();
    }
}
