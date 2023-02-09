using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.Validation;
using eOrder.Domain.Exceptions;

namespace eOrder.Domain.DayOffs.Entities
{
    public class DayOff : AggregateRoot
    {
        public DayOff(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public void Update(string name, DateTime date)
        {
            Name = name;
            Date = date;

            Validate();
        }

        private void Validate()
        {
            DomainValidation.MaxLength(Name, 100, nameof(Name));
            DomainValidation.MinLength(Name, 1, nameof(Name));

            if(Date == default)
            {
                throw new EntityValidationException($"{Date} should be truth");
            }
        }
    }
}
