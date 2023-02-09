using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Rules.Entity;

namespace eOrder.Domain.Rules.ValidationRules
{
    public interface IValidationRule
    {
        
        public Task<bool> Validate(Order order);

        public int GetCode();
    }
}
