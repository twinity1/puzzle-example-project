using Core.Data.Context;
using Modules.Abstraction.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Admin.UseCases.Examples.Detail;

public class CreateExampleCommandHandler(ICoreDataContext dataContext) : IRequestHandler<CreateExampleCommand, ExampleDetailDto>
{
    public async Task<ExampleDetailDto> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Data.ToEntity();
        
        dataContext.Examples.Add(entity);
        await dataContext.SaveChangesAsync(cancellationToken);

        return entity.ToDetailDto();
    }
}
