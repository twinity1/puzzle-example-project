using Envelope.Attributes;
using Envelope.Interfaces;
using Core.Backoffice.UseCases.Dogs.Create;
using Core.Backoffice.UseCases.Dogs.Detail;
using Core.Common.Auth.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Backoffice.UseCases.Dogs.Delete; // Import DeleteDogCommand

namespace Core.Gateway.Controllers.V1.Backoffice;

[ApiController]
[Authorize]
public class DogsController : BackofficeControllerBase
{
    [Authorize(Policy = BackofficePolicy.Dog)]
    [HttpPost(Name = "api.v1.backoffice.dogs.create")]
    [GenerateLinks]
    [ProducesResponseType<IEnvelope<DogDetailDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateAsync([FromBody] CreateDogDto dto, CancellationToken cancellationToken)
    {
        var detail = await Sender.Send(new CreateDogCommand(dto), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopeAsync(detail));
    }

    [Authorize(Policy = BackofficePolicy.Dog)]
    [HttpGet("{id:guid}", Name = "api.v1.backoffice.dogs.detail")]
    [GenerateLinks]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IEnvelope<DogDetailDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> DetailAsync(Guid id, CancellationToken cancellationToken)
    {
        var detail = await Sender.Send(new GetDogDetailQuery(id), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopeAsync(detail));
    }

    [Authorize(Policy = BackofficePolicy.Dog)]
    [HttpDelete("{id:guid}", Name = "api.v1.backoffice.dogs.delete")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IEnvelope<DogDetailDto>>(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteDogCommand(id), cancellationToken);
        return NoContent();
    }
}
