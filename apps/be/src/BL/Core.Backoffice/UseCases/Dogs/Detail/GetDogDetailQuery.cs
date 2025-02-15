using MediatR;

namespace Core.Backoffice.UseCases.Dogs.Detail;

public record GetDogDetailQuery(Guid Id) : IRequest<DogDetailDto>;
