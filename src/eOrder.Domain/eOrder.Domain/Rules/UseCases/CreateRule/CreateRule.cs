using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.Repositories;
using eOrder.Domain.Rules.UseCases.Common;

namespace eOrder.Domain.Rules.UseCases.CreateRule
{
    public class CreateRule : ICreateRule
    {

        private readonly IRulesRepository _rulesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRule(IRulesRepository rulesRepository, IUnitOfWork unitOfWork)
        {
            _rulesRepository = rulesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleOutput> Handle(CreateRuleInput request, CancellationToken cancellationToken)
        {
            var rule = new Rule(
                name: request.Name,
                description: request.Description,
                group: request.Group,
                code: request.Code,
                index: request.Index,
                runOnNews: request.RunOnNews,
                runOnModification: request.RunOnModification,
                situationOnApprove: request.SituationOnApprove,
                situationOnDisapprove: request.SituationOnDisapprove,
                parameterType: request.ParameterType,
                parameterOption: request.ParameterOption);


            await _rulesRepository.Insert(rule, cancellationToken);

            await UpdateIndex(rule, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            var output = new RuleOutput(
                id: rule.Id,
                name: rule.Name,
                description: rule.Description,
                group: rule.Group,
                code: rule.Code,
                index: rule.Index,
                runOnNews: rule.RunOnNews,
                runOnModification: rule.RunOnModification,
                isActive: rule.IsActive,
                situationOnApprove: rule.SituationOnApprove,
                situationOnDisapprove: rule.SituationOnDisapprove,
                parameterType: rule.ParameterType,
                parameterOption: rule.ParameterOption);

            return output;
        }

        private async Task UpdateIndex(Rule newRule, CancellationToken cancellationToken)
        {
            var rules = await _rulesRepository.FindAll(cancellationToken);


            var indexInUse = rules.Where(r => r.Index == newRule.Index).Any();

            if (indexInUse)
            {
                rules = rules
                    .Where(r => r.Index >= newRule.Index)
                    .OrderBy(r => r.Index)
                    .ToList();

                var index = newRule.Index + 1;
                foreach (var ruleItem in rules)
                {
                    ruleItem.UpdateIndex(index);
                    index++;
                    await _rulesRepository.Update(ruleItem, cancellationToken);
                }
            }
        }
    }
}
