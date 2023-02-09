using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Orders.Repositories;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.Factories;
using eOrder.Domain.Rules.ValidationRules;

namespace eOrder.Domain.Rules.RuleEngines
{
    public class ValidationRuleFactory : IValidationRuleFactory
    {

        private readonly ICompoundsRepository _compoundsRepository;
        private readonly ICustomersRepository _customersRepository;
        private readonly IOrdersRepository _ordersRepository;

        public ValidationRuleFactory(ICompoundsRepository compoundsRepository, ICustomersRepository customersRepository, IOrdersRepository ordersRepository)
        {
            _compoundsRepository = compoundsRepository;
            _customersRepository = customersRepository;
            _ordersRepository = ordersRepository;
        }

        public IValidationRule Create(Rule rule, Parameter parameter)
        {
            var code = rule.Code;

            return code switch
            {
                1 => new LeadTimeValidation(rule, parameter, _compoundsRepository, _customersRepository, _ordersRepository),
                _ => null!,
            };
        }
    }
}
