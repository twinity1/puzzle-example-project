using System.Text.Json;

namespace Core.Admin.UseCases.Examples.Create;

public class CreateExampleDto
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? Vat { get; set; }
    public string? Vatin { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public bool AccessSharedProducts { get; set; } = false;
    public string? Note { get; set; }
    
    public RelationDto ReleatedEntity { get; set; }
}
