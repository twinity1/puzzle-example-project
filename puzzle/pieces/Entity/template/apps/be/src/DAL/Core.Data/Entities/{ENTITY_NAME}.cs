namespace Core.Data.Entities;

public class Example
{
    public Guid Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Navigation properties
    public ICollection<ExampleChild> Children { get; set; } = new List<ExampleChild>();
}
