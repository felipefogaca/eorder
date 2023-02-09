using eOrder.Domain.Common.SeedWork;

namespace eOrder.Domain.Compounds.Entities
{
    public class Parameter : AggregateRoot
    {

        public Parameter(long ruleId, long materialId, long customerId, string value, string comparator, string valueTwo)
        {
            RuleId = ruleId;
            MaterialId = materialId;
            CustomerId = customerId;
            Value = value;
            Comparator = comparator;
            ValueTwo = valueTwo;
        }

        public long RuleId { get; private set; }
        public long MaterialId { get; private set; }
        public long CustomerId { get; private set; }
        public string Value { get; private set; }
        public string Comparator { get; private set; }
        public string ValueTwo { get; private set; }
    }
}
