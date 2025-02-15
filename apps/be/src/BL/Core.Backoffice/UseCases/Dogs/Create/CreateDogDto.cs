namespace Core.Backoffice.UseCases.Dogs.Create;

public class CreateDogDto
{
    public required string Name { get; set; }
    public string? Breed { get; set; }
    public int Age { get; set; }
}
