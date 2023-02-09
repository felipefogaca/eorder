using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Customers.Entities;
using eOrder.Domain.Customers.Repositories;
using MediatR;

namespace eOrder.Domain.Customers.UseCases.UpdateCustomer
{
    public class UpdateCustomer : IUpdateCustomer
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomer(ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCustomerInput request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.Find(request.Id, cancellationToken);

            if (customer is null)
                throw new NotFoundException($"{nameof(Customer)} not found");

            customer.Update(
                request.Name,
                request.Code,
                request.Document);

            if (request.IsActive)
                customer.Activate();
            else
                customer.Deactivate();

            var removedContacts = customer.Contacts.Where(c => !request.Contacts.Any(x => x.Id == c.Id)).ToList();

            removedContacts.ForEach(c =>
            {
                _customersRepository.RemoveContact(c);
            });

            request.Contacts.ForEach(reqContact =>
            {
                if(reqContact.Id == 0)
                {
                    var contact = new Contact(reqContact.Name, reqContact.Email, reqContact.ReceiveMail, customer.Id);
                    customer.AddContact(contact);
                }
                else
                {
                    var contact = customer.Contacts.FirstOrDefault(x => x.Id == reqContact.Id);
                    if(contact != null)
                    {
                        contact.Update(reqContact.Name, reqContact.Email, reqContact.ReceiveMail);
                    }
                    else
                    {
                        contact = new Contact(reqContact.Name, reqContact.Email, reqContact.ReceiveMail, customer.Id);
                    }
                }
            });


            await _customersRepository.Update(customer, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
