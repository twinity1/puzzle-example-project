using Core.Admin.UseCases.Examples.Detail;
using Core.Data.Context;
using MediatR;

namespace Core.Admin.UseCases.Examples.Create;

public class CreateExampleCommandHandler(ICoreDataContext dataContext) : IRequestHandler<CreateExampleCommand, ExampleDetailDto>
{
    public async Task<ExampleDetailDto> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
    {
        var relatedEntity = FindOrThrowRelatedEntity(dataContext, request.Data.RelatedEntity.Id, cancellationToken)
        
        var entity = request.Data.ToEntity(relatedEntity);
        
        dataContext.Examples.Add(entity);
        await dataContext.SaveChangesAsync(cancellationToken);

        return entity.ToDetailDto();
    }

    private async Task<RelatedEntity> FindOrThrowRelatedEntity(
        ICoreDataContext dataContext, 
        RelationDto relatedEntityDto, 
        CancellationToken cancellationToken)
    {
        return await dataContext
            .RelatedEntities
            .FirstOrDefaultAsync(x => x.Id == relatedEntityDto.Id, cancellationToken) ??
            throw new BadRequest($"Related entity with id {relatedEntityDto.Id} not found");
    }
}
