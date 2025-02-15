using Core.Data.Context;
using Modules.Abstraction.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Backoffice.UseCases.Cats.Delete;

public class DeleteCatCommandHandler(ICoreDataContext dataContext) : IRequestHandler<DeleteCatCommand>
{
    public async Task Handle(DeleteCatCommand request, CancellationToken cancellationToken)
    {
        var entity = await dataContext
            .Cats
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException($"Cat with id {request.Id} was not found");
        }

        dataContext.Cats.Remove(entity);
        await dataContext.SaveChangesAsync(cancellationToken);
    }
}
