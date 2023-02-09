using MediatR;

namespace eOrder.Domain.Orders.Events.OrderApproved
{
    public class OrderApprovedEvent : INotification
    {


        public Task Handle(OrderApprovedEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}
