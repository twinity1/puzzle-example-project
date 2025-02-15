using MediatR;

namespace Core.Backoffice.UseCases.Cats.Detail;

public record GetCatDetailQuery(Guid Id) : IRequest<CatDetailDto>;
