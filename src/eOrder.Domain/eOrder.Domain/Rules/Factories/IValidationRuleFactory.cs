using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.ValidationRules;

namespace eOrder.Domain.Rules.Factories
{
    public interface IValidationRuleFactory
    {
        public IValidationRule Create(Rule rule, Parameter parameter);
    }
}
