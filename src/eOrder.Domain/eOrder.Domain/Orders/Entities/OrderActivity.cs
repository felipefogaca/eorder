using eOrder.Domain.Common.SeedWork;

namespace eOrder.Domain.Orders.Entities
{
    public class OrderActivity : Entity
    {
        public OrderActivity(long orderId, string type, string info, string actor, long? userId, DateTime createdAt)
        {
            OrderId = orderId;
            Type = type;
            Info = info;
            Actor = actor;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public long OrderId { get; private set; }
        public string Type { get; private set; }
        public string Info { get; private set; }
        public string Actor { get; private set; }
        public long? UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
