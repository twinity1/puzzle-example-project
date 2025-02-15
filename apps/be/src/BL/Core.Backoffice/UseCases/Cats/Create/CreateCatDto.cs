namespace Core.Backoffice.UseCases.Cats.Create;

public class CreateCatDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
    public string? Breed { get; set; }
}
