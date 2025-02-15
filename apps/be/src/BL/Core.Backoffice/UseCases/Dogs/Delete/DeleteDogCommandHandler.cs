using Core.Data.Context;
using Modules.Abstraction.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Backoffice.UseCases.Dogs.Delete;

public class DeleteDogCommandHandler(ICoreDataContext dataContext) : IRequestHandler<DeleteDogCommand>
{
    public async Task Handle(DeleteDogCommand request, CancellationToken cancellationToken)
    {
        var entity = await dataContext
            .Dogs
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException($"Dog with id {request.Id} was not found");
        }

        dataContext.Dogs.Remove(entity);
        await dataContext.SaveChangesAsync(cancellationToken);
    }
}
