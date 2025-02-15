using System.ComponentModel.DataAnnotations;

namespace Core.Data.Entities;

public class Mouse
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Color { get; set; }

    public int Age { get; set; }
}
