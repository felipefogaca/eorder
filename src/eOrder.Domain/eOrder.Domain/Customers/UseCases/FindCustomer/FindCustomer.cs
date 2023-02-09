using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Customers.UseCases.Common;
using Microsoft.Extensions.Logging;

namespace eOrder.Domain.Customers.UseCases.FindCustomer
{
    public class FindCustomer : IFindCustomer
    {
        private readonly ICustomersRepository _customersRepository;
        public FindCustomer(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<CustomerOutput> Handle(FindCustomerInput request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.Find(request.Id, cancellationToken);

            if (customer == null)
                throw new Exception("Customer not found");

            var output = CustomerOutput.FromEntity(customer);

            return output;
        }
    }
}
