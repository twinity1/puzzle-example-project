using System.ComponentModel.DataAnnotations;

namespace Core.Data.Entities;

public class Cat
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string? Breed { get; set; }
}
