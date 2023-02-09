using MediatR;

namespace eOrder.Domain.Orders.UseCases.EnterOrder
{
    public class EnterOrderInput : IRequest
    {
        public EnterOrderInput(string requestNumber, string customer, string compound, string orderType, DateTime shippingDate, decimal quantity, int releaseNumber)
        {
            RequestNumber = requestNumber;
            CustomerDocument = customer;
            CompoundCode = compound;
            OrderType = orderType;
            ShippingDate = shippingDate;
            Quantity = quantity;
            ReleaseNumber = releaseNumber;
        }

        public string RequestNumber { get; set; }
        public string CustomerDocument { get; set; }
        public string CompoundCode { get; set; }
        public string OrderType { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal Quantity { get; set; }
        public int ReleaseNumber { get; set; }
    }
}
