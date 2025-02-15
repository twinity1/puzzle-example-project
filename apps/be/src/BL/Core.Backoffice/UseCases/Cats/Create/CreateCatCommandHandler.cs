using Core.Backoffice.UseCases.Cats.Detail;
using Core.Data.Context;
using Core.Data.Entities;
using MediatR;

namespace Core.Backoffice.UseCases.Cats.Create;

public class CreateCatCommandHandler(ICoreDataContext dataContext) : IRequestHandler<CreateCatCommand, CatDetailDto>
{
    public async Task<CatDetailDto> Handle(CreateCatCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Data.ToEntity();

        dataContext.Cats.Add(entity);
        await dataContext.SaveChangesAsync(cancellationToken);

        return entity.ToDetailDto();
    }
}
