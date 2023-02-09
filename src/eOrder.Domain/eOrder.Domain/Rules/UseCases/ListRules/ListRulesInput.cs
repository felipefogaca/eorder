using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Common.UseCases;
using eOrder.Domain.Customers.UseCases.ListCustomers;
using MediatR;

namespace eOrder.Domain.Rules.UseCases.ListRules
{
    public class ListRulesInput : PaginatedListInput, IRequest<ListRulesOutput>
    {
        public ListRulesInput(int page, int perPage, string search, string sort, SearchOrder dir) : base(page, perPage, search, sort, dir)
        {
        }

        public ListRulesInput()
            : base(1, 15, "", "", SearchOrder.Asc)
        {

        }
    }
}
