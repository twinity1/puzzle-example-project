using Core.Data.Entities;

namespace Core.Backoffice.UseCases.Dogs.Detail;

public static class DogDetailMappingExtensions
{
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
