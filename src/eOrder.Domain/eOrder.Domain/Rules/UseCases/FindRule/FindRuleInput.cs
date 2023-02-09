using eOrder.Domain.Rules.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Rules.UseCases.FindRule
{
    public class FindRuleInput : IRequest<RuleOutput>
    {
        public FindRuleInput(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

    }
}
