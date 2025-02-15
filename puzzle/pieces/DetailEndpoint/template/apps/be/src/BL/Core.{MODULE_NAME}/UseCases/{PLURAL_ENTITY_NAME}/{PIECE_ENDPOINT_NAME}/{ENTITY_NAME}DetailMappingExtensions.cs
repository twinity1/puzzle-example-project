using Core.Data.Entities;

namespace Core.Admin.UseCases.Examples.Detail;

public static class ExampleDetailMappingExtensions
{
    public static ExampleDetailDto ToDetailDto(this Example entity)
    {
        return new ExampleDetailDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Address = entity.Address,
            Vat = entity.Vat,
            Vatin = entity.Vatin,
            ContactName = entity.ContactName,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            AccessSharedProducts = entity.AccessSharedProducts,
            Note = entity.Note,
        };
    }   
}
