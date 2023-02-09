using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Customers.Entities;
using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Orders.ValueObjects;

namespace eOrder.Domain.Orders.Factories
{
    public class OrderFactory
    {
        public static Order CreateNewOrder(
            string requestNumber, 
            decimal quantity, 
            string orderType, 
            DateTime shippingDate, 
            int releaseNumber,
            Customer customer, 
            Compound compound
            )
        {
            var release = new Release(releaseNumber, quantity);

            var order = new Order(
                    requestNumber: requestNumber,
                    customerId: customer.Id,
                    customerName: customer.Name,
                    compoundId: compound.Id,
                    compoundCode: compound.Code,
                    compoundDescription: compound.Description,
                    release: release,
                    releaseFinal: release,
                    orderType: orderType,
                    shippingDate: shippingDate,
                    purchaseOrder: "",
                    orderSituation: orderType == Order.Type.Firm ?  Order.Situation.Processing : Order.Situation.Future,
                    standardQuantity: compound.StandardQuantity,
                    null);

            return order;
        }

    }
}
