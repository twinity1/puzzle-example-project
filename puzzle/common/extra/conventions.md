# NET / Backend
- project uses NET 8.0
- use `obj.Property is null` instead of `obj.Property == null`
- use primary constructor for every class - class SomeClass(IService service) {}
- nested DTOs must have annotation [SchemaId<MainDto>] and link to the originalDto via generic argument. This is very important. (except RelationDto for input data)
- nested DTOs must be in another nested folder (except RelationDto)
- the nested DTO must on path: ./{NESTED_ENTITY_NAME}/{NESTED_ENTITY_NAME}Dto (the main dto is on path ./MainDto)
- ask for the file creation!!! do not put it in the same class as the main dto!!
- 400 (bad request) query/commands validation must be in Validator file and use library FluentValidations
  - for specific rules add new code to ErrorCodes - new error code must start with module name
- RelationDto must be used for related entities for input data in commands
- use `dbContext.Add()` instead of `dbContext.AddAsync()`
- comment controller endpoints, handlers and services
- name of async methods must end with Async
- method Handle of Handler class must always return a Dto object, not the entity directly, for example return entity.ToDetailDto()
- Return createdBy, editedBy, createdDate, etc. properties in DTO for backoffice handlers