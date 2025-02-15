using Envelope.Attributes;
using Envelope.Interfaces;
using Core.Backoffice.UseCases.Cats.Create;
using Core.Backoffice.UseCases.Cats.Detail;
using Core.Backoffice.UseCases.Cats.Delete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Gateway.Controllers.V1.Backoffice;

[ApiController]
[Authorize]
public class CatsController : BackofficeControllerBase
{
    [HttpPost(Name = "api.v1.backoffice.cats.create")]
    [GenerateLinks]
    [ProducesResponseType<IEnvelope<CatDetailDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateAsync([FromBody] CreateCatDto dto, CancellationToken cancellationToken)
    {
        var detail = await Sender.Send(new CreateCatCommand(dto), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopeAsync(detail));
    }

    [HttpDelete("{id:guid}", Name = "api.v1.backoffice.cats.delete")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IEnvelope<CatDetailDto>>(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteCatCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:guid}", Name = "api.v1.backoffice.cats.detail")]
    [GenerateLinks]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IEnvelope<CatDetailDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> DetailAsync(Guid id, CancellationToken cancellationToken)
    {
        var detail = await Sender.Send(new GetCatDetailQuery(id), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopeAsync(detail));
    }
}
