using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Common.UseCases;
using MediatR;

namespace eOrder.Domain.Customers.UseCases.ListCustomers
{
    public class ListCustomersInput : PaginatedListInput, IRequest<ListCustomersOutput>
    {
        public ListCustomersInput(int page, int perPage, string search, string sort, SearchOrder dir) : base(page, perPage, search, sort, dir)
        {
        }

        public ListCustomersInput()
            : base(1, 15, "", "", SearchOrder.Asc)
        {

        }
    }
}
