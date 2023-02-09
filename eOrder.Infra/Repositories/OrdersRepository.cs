using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Orders.Repositories;

namespace eOrder.Infra.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public Task Delete(Order aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Find(long customerId, long compoundId, string requestNumber, DateTime shippingDate)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> Find(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Order aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
