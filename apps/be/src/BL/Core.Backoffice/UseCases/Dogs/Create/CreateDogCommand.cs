using Core.Backoffice.UseCases.Dogs.Detail;
using MediatR;

namespace Core.Backoffice.UseCases.Dogs.Create;

public record CreateDogCommand(CreateDogDto Data) : IRequest<DogDetailDto>;
