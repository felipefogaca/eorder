using eOrder.Api.ApiModels;
using eOrder.Api.ApiModels.Responses;
using eOrder.Api.ApiModels.Rules;
using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Customers.UseCases.ListCustomers;
using eOrder.Domain.Rules.UseCases.Common;
using eOrder.Domain.Rules.UseCases.CreateRule;
using eOrder.Domain.Rules.UseCases.FindRule;
using eOrder.Domain.Rules.UseCases.ListRules;
using eOrder.Domain.Rules.UseCases.UpdateRule;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eOrder.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateRuleInput input,
            CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(input, cancellationToken);

            return CreatedAtAction(nameof(Create), new { output.Id }, new ApiResponse<RuleOutput>(output));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(
            [FromRoute] long id,
            [FromBody] UpdateRuleApiInput apiInput,
            CancellationToken cancellationToken)
        {
            var input = new UpdateRuleInput(
                id: id,
                name: apiInput.Name,
                description: apiInput.Description,
                group: apiInput.Group,
                code: apiInput.Code,
                index: apiInput.Index,
                runOnNews: apiInput.RunOnNews,
                runOnModification: apiInput.RunOnModification,
                isActive: apiInput.IsActive,
                situationOnApprove: apiInput.SituationOnApprove,
                situationOnDisapprove: apiInput.SituationOnDisapprove,
                parameterType: apiInput.ParameterType,
                parameterOption: apiInput.ParameterOption);

            await _mediator.Send(input, cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Find(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var input = new FindRuleInput(id);

            var output = await _mediator.Send(input, cancellationToken);

            return Ok(new ApiResponse<RuleOutput>(output));
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage,
            [FromQuery(Name = "search")] string? search,
            [FromQuery(Name = "sort")] string? sort,
            [FromQuery(Name = "dir")] string dir)
        {


            var input = new ListRulesInput();
            if (page is not null) input.Page = page.Value;
            if (perPage is not null) input.PerPage = perPage.Value;
            if (search is not null) input.Search = search;
            if (dir is not null) input.Dir = dir.ToLower() == "asc" ? SearchOrder.Asc : SearchOrder.Desc;
            if (sort is not null) input.Sort = sort;

            var output = await _mediator.Send(input, cancellationToken);

            return Ok(new ApiResponseList<RuleOutput>(output));
        }
    }
}
