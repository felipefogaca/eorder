using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Orders.Entities;

namespace eOrder.Domain.Orders.Repositories
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        Task<Order> Find(long customerId, long compoundId, string requestNumber, DateTime shippingDate);
    }
}
