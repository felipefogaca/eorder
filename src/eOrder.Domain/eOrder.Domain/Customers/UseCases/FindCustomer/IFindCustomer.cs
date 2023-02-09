using eOrder.Domain.Customers.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Customers.UseCases.FindCustomer
{
    public interface IFindCustomer : IRequestHandler<FindCustomerInput, CustomerOutput>
    {

    }
}
