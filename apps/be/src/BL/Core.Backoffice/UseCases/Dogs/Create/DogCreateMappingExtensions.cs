using Core.Data.Entities;
using Core.Backoffice.UseCases.Dogs.Detail;

namespace Core.Backoffice.UseCases.Dogs.Create;

public static class DogCreateMappingExtensions
{
    public static Dog ToEntity(this CreateDogDto dto)
    {
        return new Dog
        {
            Name = dto.Name,
            Breed = dto.Breed,
            Age = dto.Age
        };
    }

    public static DogDetailDto ToDetailDto(this Dog entity)
    {
        return new DogDetailDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Breed = entity.Breed,
            Age = entity.Age
        };
    }
}
