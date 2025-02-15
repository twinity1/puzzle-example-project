using System.Reflection;
using Core.Data.Context;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Core.Data.Seeds.Entities;

public class MessageTemplateSeed(
    ICoreDataContext dataContext,
    IOptionsSnapshot<SeedSettings> optionsSnapshot)
    : IEntitySeedService
{
    // Prepare entities
    public static readonly MessageTemplate ContactForm = new()
    {
        Id = Guid.Parse("a4b60c4b-0c36-417b-8534-a470303298a5"),
        Code = "CONTACT_FORM",
        SubjectTemplate = "Bistro Inspirace - Zpráva z kontaktního formuláře",
        CreatedAt = DateTime.UtcNow,
        AutoDelete = false,
    };
    
    public static readonly MessageTemplate UserCreated = new()
    {
        Id = Guid.Parse("a4b60c4b-0c36-417b-8534-a470303298aa"),
        Code = "USER_CREATED",
        SubjectTemplate = "Vítejte v @Model.SystemName",
        CreatedAt = DateTime.UtcNow
    };
    
    public static readonly MessageTemplate BackofficeResetPassword = new()
    {
        Id = Guid.Parse("e6f6a819-bc3a-40d7-bde7-7c2c5cdf1d8f"),
        Code = "BACKOFFICE_RESET_PASSWORD",
        SubjectTemplate = "Pikit - Obnova hesla",
        BodyTemplate = "Někdo požádal o změnu hesla v systému Pikit. Pro změnu hesla klikněte na <a href=\"@Model.LandingPageAbsoluteUrlWithToken\">tento odkaz</a>.",
        CreatedAt = DateTime.UtcNow,
        AutoDelete = true,
    };

    // All entities list
    private static readonly MessageTemplate[] All =
    [
        ContactForm,
        UserCreated,
        BackofficeResetPassword
    ];
    
    public async Task SeedRecordsAsync(CancellationToken cancellationToken)
    {
        if (optionsSnapshot.Value.Example.Enabled == false)
        {
            return;
        }
        
        dataContext.ClearChangeTracker();

        foreach (var template in All)
        {
            var existing = await dataContext.Examples
                .FirstOrDefaultAsync(x => x.Id == template.Id, cancellationToken);

            if (existing is null)
            {
                dataContext.MessageTemplates.Add(template);
            }
            else
            {
                // Update
                existing.BodyTemplate = template.BodyTemplate;
                existing.SubjectTemplate = template.SubjectTemplate;
            }
        }
        
        await dataContext.SaveChangesAsync(cancellationToken);
    }
}
