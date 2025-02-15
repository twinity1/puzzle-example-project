using Core.Backoffice.UseCases.Cats.Detail;
using MediatR;

namespace Core.Backoffice.UseCases.Cats.Create;

public record CreateCatCommand(CreateCatDto Data) : IRequest<CatDetailDto>;
