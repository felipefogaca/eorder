using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Customers.Entities;
using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Customers.UseCases.Common;

namespace eOrder.Domain.Customers.UseCases.CreateCustomer
{
    public class CreateCustomer : ICreateCustomer
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomer(ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerOutput> Handle(CreateCustomerInput request, CancellationToken cancellationToken)
        {
            var customer = new Customer(
                request.Name,
                request.Code,
                request.Document,
                request.IsActive);

            request.Contacts.ForEach(c =>
            {
                var contact = new Contact(c.Name, c.Email, c.ReceiveMail, customer.Id);
                customer.AddContact(contact);
            });


            await _customersRepository.Insert(customer, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            var output = CustomerOutput.FromEntity(customer);

            return output;
        }
    }
}
