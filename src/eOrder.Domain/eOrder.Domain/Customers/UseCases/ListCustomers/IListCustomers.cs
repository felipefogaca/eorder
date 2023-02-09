using MediatR;

namespace eOrder.Domain.Customers.UseCases.ListCustomers
{
    public interface IListCustomers : IRequestHandler<ListCustomersInput, ListCustomersOutput>
    {

    }
}
