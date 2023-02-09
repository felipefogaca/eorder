using eOrder.Domain.Customers.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Customers.UseCases.FindCustomer
{
    public class FindCustomerInput : IRequest<CustomerOutput>
    {
        public FindCustomerInput(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}
