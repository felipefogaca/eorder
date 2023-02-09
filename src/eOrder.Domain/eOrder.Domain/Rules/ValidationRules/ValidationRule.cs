using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Orders.Repositories;
using eOrder.Domain.Rules.Entity;

namespace eOrder.Domain.Rules.ValidationRules
{
    public abstract class ValidationRule : IValidationRule
    {
        protected readonly ICompoundsRepository _compoundsRepository;
        protected readonly ICustomersRepository _customersRepository;
        protected readonly IOrdersRepository _ordersRepository;
        protected readonly Rule _rule;
        protected readonly Parameter _parameter;

        protected ValidationRule(Rule rule, Parameter parameter, ICompoundsRepository compoundsRepository, ICustomersRepository customersRepository, IOrdersRepository ordersRepository)
        {
            _compoundsRepository = compoundsRepository;
            _customersRepository = customersRepository;
            _ordersRepository = ordersRepository;

            _rule = rule;
            _parameter = parameter;
        }

        public abstract int GetCode();

        public abstract Task<bool> Validate(Order order);
    }
}
