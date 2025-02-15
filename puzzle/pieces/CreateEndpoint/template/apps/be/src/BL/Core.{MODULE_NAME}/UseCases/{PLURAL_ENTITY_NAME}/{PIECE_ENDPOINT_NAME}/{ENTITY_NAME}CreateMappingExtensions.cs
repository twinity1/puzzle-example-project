using Core.Data.Entities;

namespace Core.Admin.UseCases.Examples.Create;

public static class GetExampleMappingCreateExtensions
{
    public static Example ToEntity(this CreateExampleDto dto, RelatedEntity relatedEntity)
    {
        return new Example
        {
            Name = dto.Name,
            Address = dto.Address,
            Vat = dto.Vat,
            Vatin = dto.Vatin,
            ContactName = dto.ContactName,
            ContactEmail = dto.ContactEmail,
            ContactPhone = dto.ContactPhone,
            AccessSharedProducts = dto.AccessSharedProducts,
            Note = dto.Note,
            ReleatedEntity = relatedEntity
        };
    }
}
