example-project-setup/puzzle/pieces/CustomQueryEndpoint/template/apps/be/src/BL/Core.{MODULE_NAME}/UseCases/{PLURAL_ENTITY_NAME}/{CUSTOM_ACTION_NAME}/{CUSTOM_ACTION_FULL_NAME}Query.cs
using MediatR;

namespace Core.Admin.UseCases.Examples.Detail;

public record GetExampleDetailQuery(Guid Id) : IRequest<ExampleDetailDto>;
