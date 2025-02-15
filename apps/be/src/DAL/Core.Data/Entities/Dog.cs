namespace Core.Data.Entities;

public class Dog
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Breed { get; set; }
    public int Age { get; set; }

    // Navigation properties
    // Example of a navigation property (if a Dog has an owner, for example)
    // public Guid OwnerId { get; set; }
    // public Owner Owner { get; set; } = null!;
}
