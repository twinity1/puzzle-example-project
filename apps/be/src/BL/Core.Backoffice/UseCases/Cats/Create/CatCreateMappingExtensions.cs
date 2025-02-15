using Core.Backoffice.UseCases.Cats.Detail;
using Core.Data.Entities;

namespace Core.Backoffice.UseCases.Cats.Create;

public static class CatCreateMappingExtensions
{
    public static Cat ToEntity(this CreateCatDto dto)
    {
        return new Cat
        {
            Name = dto.Name,
            Age = dto.Age,
            Breed = dto.Breed
        };
    }

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
