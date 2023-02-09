using eOrder.Domain.Customers.Repositories;

namespace eOrder.Domain.Customers.UseCases.ListCustomers
{
    public class ListCustomers : IListCustomers
    {
        private readonly ICustomersRepository _customersRepository;

        public ListCustomers(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<ListCustomersOutput> Handle(ListCustomersInput request, CancellationToken cancellationToken)
        {
            var searchOutput = await _customersRepository.Search(request.ToSearchInput(), cancellationToken);

            return ListCustomersOutput.FromSearchOutput(searchOutput);
        }
    }
}
