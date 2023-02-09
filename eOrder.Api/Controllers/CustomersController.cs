using eOrder.Api.ApiModels;
using eOrder.Api.ApiModels.Customers;
using eOrder.Api.ApiModels.Responses;
using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Customers.UseCases.Common;
using eOrder.Domain.Customers.UseCases.CreateCustomer;
using eOrder.Domain.Customers.UseCases.FindCustomer;
using eOrder.Domain.Customers.UseCases.ListCustomers;
using eOrder.Domain.Customers.UseCases.UpdateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eOrder.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var input = new FindCustomerInput(id);

            var output = await _mediator.Send(input, cancellationToken);

            return Ok(new ApiResponse<CustomerOutput>(output));
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage,
            [FromQuery(Name = "search")] string? search,
            [FromQuery(Name = "sort")] string? sort,
            [FromQuery(Name = "dir")] string? dir)
        {
            var input = new ListCustomersInput();
            if (page is not null) input.Page = page.Value;
            if (perPage is not null) input.PerPage = perPage.Value;
            if (search is not null) input.Search = search;
            if (dir is not null) input.Dir = dir.ToLower() == "asc" ? SearchOrder.Asc : SearchOrder.Desc;
            if (sort is not null) input.Sort = sort;

            var output = await _mediator.Send(input, cancellationToken);

            return Ok(new ApiResponseList<CustomerOutput>(output));
        }


        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerInput input,
            CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(input, cancellationToken);

            return CreatedAtAction(nameof(Create), new { output.Id }, new ApiResponse<CustomerOutput>(output));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(
            [FromRoute] long id,
            [FromBody] UpdateCustomerApiInput apiInput,
            CancellationToken cancellationToken)
        {
            var input = new UpdateCustomerInput(
                id: id,
                name: apiInput.Name,
                code: apiInput.Code,
                document: apiInput.Document,
                apiInput.IsActive,
                apiInput.Contacts);

            await _mediator.Send(input, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete()
        {
            return await Task.FromResult(StatusCode(500));
        }
    }
}
