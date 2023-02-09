using MediatR;

namespace eOrder.Domain.Rules.UseCases.ListRules
{
    public interface IListRules : IRequestHandler<ListRulesInput, ListRulesOutput>
    {
    }
}
