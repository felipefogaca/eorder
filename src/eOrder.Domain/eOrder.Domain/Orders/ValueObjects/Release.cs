using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Exceptions;

namespace eOrder.Domain.Orders.ValueObjects
{
    public class Release : ValueObject
    {
        public Release(int number, decimal quantity)
        {
            Number = number;
            Quantity = quantity;

            Validate();
        }

        public int Number { get; private set; }
        public decimal Quantity { get; private set; }


        private void Validate()
        {
            if(Number < -1)
            {
                throw new EntityValidationException($"{nameof(Number)} should be greater than or equal to -1");
            }

            if(Quantity < 0)
            {
                throw new EntityValidationException($"{nameof(Quantity)} should be greater than or equal to 0");
            }
        }

        public override bool Equals(ValueObject? other)
        {
            return other is Release release 
                && Number == release.Number 
                && Quantity == release.Quantity;
        }

        protected override int GetCustomHashCode()
        {
            return HashCode.Combine($"{Number}-{Quantity}");
        }
    }
}
