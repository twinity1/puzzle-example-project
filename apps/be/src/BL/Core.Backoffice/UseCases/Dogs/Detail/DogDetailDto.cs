using System.Text.Json;

namespace Core.Backoffice.UseCases.Dogs.Detail;

public class DogDetailDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Breed { get; set; }
    public int Age { get; set; }
}
