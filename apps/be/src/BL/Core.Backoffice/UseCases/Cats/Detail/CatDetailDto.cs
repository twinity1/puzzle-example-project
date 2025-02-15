namespace Core.Backoffice.UseCases.Cats.Detail;

public class CatDetailDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public string? Breed { get; set; }
}
