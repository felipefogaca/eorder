using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Common.UseCases;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.UseCases.Common;

namespace eOrder.Domain.Rules.UseCases.ListRules
{
    public class ListRulesOutput : PaginatedListOutput<RuleOutput>
    {
        protected ListRulesOutput(int page, int perPage, int total, IReadOnlyList<RuleOutput> items) : base(page, perPage, total, items)
        {
        }

        internal static ListRulesOutput FromSearchOutput(SearchOutput<Rule> searchOutput)
        {
            return new(
                searchOutput.CurrentPage,
                searchOutput.PerPage,
                searchOutput.Total,
                searchOutput.Items
                .Select(rule => RuleOutput.FromEntity(rule))
                .ToList());
        }
    }
}
