using Envelope.Attributes;
using Envelope.Interfaces;
using FilterExpressionBuilder.FilterDataSources;
using FilterExpressionBuilder.Paging;
using Core.Admin.UseCases.Examples.Create;
using Core.Admin.UseCases.Examples.Delete;
using Core.Admin.UseCases.Examples.Detail;
using Core.Admin.UseCases.Examples.List;
using Core.Admin.UseCases.Examples.ListEnum;
using Core.Admin.UseCases.Examples.Update;
using Core.Common.Auth.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Gateway.Controllers.V1.Admin;

[ApiController]
[Authorize]
public class ExampleController : BackofficeControllerBase // or WebControllerBase
{
    [Authorize(Policy = BackofficePolicy.Example)]
    [HttpPost(Name = "api.v1.admin.examples.create")]
    [GenerateLinks]
    [ProducesResponseType<IEnvelope<ExampleDetailDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateAsync([FromBody] CreateExampleDto dto, CancellationToken cancellationToken)
    {
        var detail = await Sender.Send(new CreateExampleCommand(dto), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopeAsync(detail));
    }

    [Authorize(Policy = BackofficePolicy.Example)]
    [HttpGet("{id:guid}", Name = "api.v1.admin.examples.detail")]
    [GenerateLinks]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IEnvelope<ExampleDetailDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> DetailAsync(Guid id, CancellationToken cancellationToken)
    {
        var detail = await Sender.Send(new GetExampleDetailQuery(id), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopeAsync(detail));
    }

    [Authorize(Policy = BackofficePolicy.Example)]
    [HttpPut("{id:guid}", Name = "api.v1.admin.examples.update")]
    [GenerateLinks]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IEnvelope<ExampleDetailDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateExampleDto dto, CancellationToken cancellationToken)
    {
        var detail = await Sender.Send(new UpdateExampleCommand(id, dto), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopeAsync(detail));
    }

    [Authorize(Policy = BackofficePolicy.Example)]
    [HttpDelete("{id:guid}", Name = "api.v1.admin.examples.delete")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IEnvelope<ExampleDetailDto>>(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteExampleCommand(id), cancellationToken);
        return NoContent();
    }

    [Authorize(Policy = BackofficePolicy.Example)]
    [HttpGet(Name = "api.v1.admin.examples.get.list")]
    [GenerateLinks]
    [ProducesResponseType<IPagingObject<IEnvelope<ExamplePreviewDto>>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetListAsync([FromQuery] StringFiltersDataSource dataSource, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetExampleListQuery(dataSource), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopesAsync(result));
    }

    [HttpGet("enum", Name = "api.v1.admin.examples.get.list-enum")]
    [GenerateLinks]
    [ProducesResponseType<IPagingObject<IEnvelope<ExampleEnumDto>>>(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetListEnumAsync([FromQuery] StringFiltersDataSource dataSource, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetExampleListEnumQuery(dataSource), cancellationToken);
        return Ok(await EnvelopeOutputGenerator.EmitEnvelopesAsync(result));
    }
}
