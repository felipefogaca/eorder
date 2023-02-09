using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Common.UseCases;
using eOrder.Domain.Customers.Entities;
using eOrder.Domain.Customers.UseCases.Common;

namespace eOrder.Domain.Customers.UseCases.ListCustomers
{
    public class ListCustomersOutput : PaginatedListOutput<CustomerOutput>
    {
        protected ListCustomersOutput(int page, int perPage, int total, IReadOnlyList<CustomerOutput> items) : base(page, perPage, total, items)
        {
        }

        internal static ListCustomersOutput FromSearchOutput(SearchOutput<Customer> searchOutput)
        {
            return new(
                searchOutput.CurrentPage,
                searchOutput.PerPage,
                searchOutput.Total,
                searchOutput.Items
                .Select(customer => CustomerOutput.FromEntity(customer))
                .ToList());
        }
    }
}
