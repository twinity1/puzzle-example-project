namespace DefaultNamespace;

public class CreateExampleValidator : AbstractValidator<CreateClientCommand> // or query
{
    public CreateExampleValidator(CoreDataContext dataContext)
    {
        RuleFor(x => x.Data.Region.Id)
            .MustAsync(async (regionId, token) => await dataContext.Regions.AnyAsync(x => x.Id == regionId, token))
            .WithErrorCode(ErrorCodes.InvalidForeignKey.ToString());
        
        RuleFor(x => x.Data.RelationshipType.Id)
            .MustAsync(async (relationshipTypeId, token) => await dataContext.RelationshipTypes.AnyAsync(x => x.Id == relationshipTypeId, token))
            .WithErrorCode(ErrorCodes.InvalidForeignKey.ToString());
    }
}
