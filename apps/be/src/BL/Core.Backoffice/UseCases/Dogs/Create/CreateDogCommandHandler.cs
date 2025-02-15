using Core.Backoffice.UseCases.Dogs.Detail;
using Core.Data.Context;
using MediatR;

namespace Core.Backoffice.UseCases.Dogs.Create;

public class CreateDogCommandHandler(ICoreDataContext dataContext) : IRequestHandler<CreateDogCommand, DogDetailDto>
{
    public async Task<DogDetailDto> Handle(CreateDogCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Data.ToEntity();

        dataContext.Dogs.Add(entity);
        await dataContext.SaveChangesAsync(cancellationToken);

        return entity.ToDetailDto();
    }
}
