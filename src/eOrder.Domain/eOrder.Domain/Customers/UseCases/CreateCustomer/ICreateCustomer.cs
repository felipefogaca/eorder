using eOrder.Domain.Customers.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Customers.UseCases.CreateCustomer
{
    public interface ICreateCustomer : IRequestHandler<CreateCustomerInput, CustomerOutput>
    {

    }
}
