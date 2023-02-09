using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.Repositories;
using MediatR;

namespace eOrder.Domain.Rules.UseCases.UpdateRule
{
    public class UpdateRule : IUpdateRule
    {
        private readonly IRulesRepository _rulesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRule(IRulesRepository rulesRepository, IUnitOfWork unitOfWork)
        {
            _rulesRepository = rulesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateRuleInput request, CancellationToken cancellationToken)
        {
            var rule = await _rulesRepository.Find(request.Id, cancellationToken);

            if (rule is null)
                throw new NotFoundException($"{nameof(Rule)} not found");


            await UpdateIndex(rule, request.Index,  cancellationToken);

            rule.Update(
                name: request.Name,
                description: request.Description,
                group: request.Group,
                index: request.Index,
                runOnNews: request.RunOnNews,
                runOnModification: request.RunOnModification,
                situationOnApprove: request.SituationOnApprove,
                situationOnDisapprove: request.SituationOnDisapprove,
                parameterType: request.ParameterType,
                parameterOption: request.ParameterOption);


            

            if (request.IsActive)
                rule.Activate();
            else
                rule.Deactivate();



            await _rulesRepository.Update(rule, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }

        private async Task UpdateIndex(Rule updateRule, int newIndex, CancellationToken cancellationToken)
        {
            var rules = await _rulesRepository.FindAll(cancellationToken);

            rules = rules.OrderBy(r => r.Index).ToList();

            var indexCounter = 0;
            foreach(var rule in rules)
            {
                indexCounter++;

                if (rule.Id == updateRule.Id)
                    continue;

                if (indexCounter == newIndex)
                    indexCounter++;

                rule.UpdateIndex(indexCounter);
            }

            rules = rules.OrderBy(r => r.Index).ToList();

            indexCounter = 1;
            foreach(var rule in rules)
            {
                
                rule.UpdateIndex(indexCounter);
                indexCounter++;
                await _rulesRepository.Update(rule, cancellationToken);
            }

        }
    }
}
