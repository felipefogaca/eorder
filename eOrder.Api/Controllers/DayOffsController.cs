using eOrder.Api.ApiModels;
using eOrder.Api.ApiModels.DayOffs;
using eOrder.Domain.DayOffs.UseCases.Common;
using eOrder.Domain.DayOffs.UseCases.CreateDayOff;
using eOrder.Domain.DayOffs.UseCases.DeleteDayOff;
using eOrder.Domain.DayOffs.UseCases.FindDayOff;
using eOrder.Domain.DayOffs.UseCases.ListDayOffs;
using eOrder.Domain.DayOffs.UseCases.UpdateDayOff;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eOrder.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DayOffsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DayOffsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var input = new FindDayOffInput(id);

            var output = await _mediator.Send(input, cancellationToken);

            return Ok(new ApiResponse<DayOffOutput>(output));
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery(Name = "start_date")] DateTime? startDate,
            [FromQuery(Name ="end_date")] DateTime? endDate,
            CancellationToken cancellationToken)
        {
            var input = new ListDayOffsInput();

            if (startDate is not null) input.StartDate = startDate.Value;
            if (endDate is not null) input.EndDate = endDate.Value;

            var output = await _mediator.Send(input, cancellationToken);

            return Ok(new ApiResponse<List<DayOffOutput>>(output));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateDayOffInput input,
            CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(input, cancellationToken);

            return CreatedAtAction(nameof(Create), new { output.Id }, new ApiResponse<DayOffOutput>(output));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(
            [FromRoute] long id,
            [FromBody] UpdateDayOffApiInput apiInput,
            CancellationToken cancellationToken)
        {
            var input = new UpdateDayOffInput(
                id, 
                apiInput.Name,
                apiInput.Date);

            await _mediator.Send(input, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var input = new DeleteDayOffInput(id);

            var output = await _mediator.Send(input, cancellationToken);

            return Ok(new ApiResponse<DayOffOutput>(output));
        }

    }
}
