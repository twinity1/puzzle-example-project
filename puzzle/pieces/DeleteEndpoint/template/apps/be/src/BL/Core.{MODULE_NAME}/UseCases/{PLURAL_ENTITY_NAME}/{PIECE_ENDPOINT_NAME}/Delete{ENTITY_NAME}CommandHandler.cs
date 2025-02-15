using Core.Data.Context;
using Modules.Abstraction.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Admin.UseCases.Examples.Delete;

public class DeleteExampleCommandHandler(ICoreDataContext dataContext) : IRequestHandler<DeleteExampleCommand>
{
    public async Task Handle(DeleteExampleCommand request, CancellationToken cancellationToken)
    {
        var entity = await dataContext
            .Examples
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException($"Entity with {request.Id} was not found");
        }

        dataContext.Examples.Remove(entity);
        await dataContext.SaveChangesAsync(cancellationToken);
    }
}
