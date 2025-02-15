using Core.Data.Entities;

namespace Core.Backoffice.UseCases.Cats.Detail;

public static class CatDetailMappingExtensions
{
    public static CatDetailDto ToDetailDto(this Cat entity)
    {
        return new CatDetailDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Age = entity.Age,
            Breed = entity.Breed
        };
    }
}
