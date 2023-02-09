using MediatR;

namespace eOrder.Domain.Orders.Events.OrderApproved
{
    public class OrderApprovedEventHandler : INotificationHandler<OrderApprovedEvent>
    {
        public Task Handle(OrderApprovedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
