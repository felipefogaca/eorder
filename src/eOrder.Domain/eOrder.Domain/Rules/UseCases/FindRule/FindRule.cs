using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.Repositories;
using eOrder.Domain.Rules.UseCases.Common;

namespace eOrder.Domain.Rules.UseCases.FindRule
{
    public class FindRule : IFindRule
    {
        private readonly IRulesRepository _rulesRepository;

        public FindRule(IRulesRepository rulesRepository)
        {
            _rulesRepository = rulesRepository;
        }

        public async Task<RuleOutput> Handle(FindRuleInput request, CancellationToken cancellationToken)
        {
            var rule = await _rulesRepository.Find(request.Id, cancellationToken);

            if (rule is null)
                throw new NotFoundException($"{nameof(Rule)} not found");


            var output = RuleOutput.FromEntity(rule);

            return output;
        }
    }
}
