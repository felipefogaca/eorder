using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.Validation;
using eOrder.Domain.Orders.ValueObjects;

namespace eOrder.Domain.Orders.Entities
{
    public class ReleaseHistory : Entity
    {
        public ReleaseHistory(long orderId, Release release, string orderType, DateTime createdAt)
        {
            OrderId = orderId;
            Release = release;
            OrderType = orderType;
            CreatedAt = createdAt;

            Validate();
        }

        public long OrderId { get; private set; }
        public Release Release { get; private set; }
        public string OrderType { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private void Validate()
        {
            DomainValidation.NotNullOrEmpty(OrderType, nameof(OrderType));
            DomainValidation.NotNull(Release, nameof(Release));
        }
    }
}
