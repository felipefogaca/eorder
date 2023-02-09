using MediatR;

namespace eOrder.Domain.Customers.UseCases.UpdateCustomer
{
    public class UpdateCustomerInput : IRequest
    {
        public UpdateCustomerInput(long id, string name, string code, string document, bool isActive, List<UpdateContactInput> contacts)
        {
            Id = id;
            Name = name;
            Code = code;
            Document = document;
            IsActive = isActive;
            Contacts = contacts;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Document { get; private set; }
        public bool IsActive { get; private set; }
        public List<UpdateContactInput> Contacts { get; set; }
    }
}
