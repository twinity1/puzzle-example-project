using Core.Data.Context;
using Modules.Abstraction.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Backoffice.UseCases.Dogs.Detail;

public class GetDogDetailQueryHandler(ICoreDataContext context)
    : IRequestHandler<GetDogDetailQuery, DogDetailDto>
{
    public async Task<DogDetailDto> Handle(GetDogDetailQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await context.Dogs
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException($"Dog with id {request.Id} was not found");
        }

        return entity.ToDetailDto();
    }
}
