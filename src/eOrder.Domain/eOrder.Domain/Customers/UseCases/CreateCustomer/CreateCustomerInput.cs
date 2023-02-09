using eOrder.Domain.Customers.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Customers.UseCases.CreateCustomer
{
    public class CreateCustomerInput : IRequest<CustomerOutput>
    {
        public CreateCustomerInput(string name, string code, string document, bool isActive, List<CreateContactInput> contacts)
        {
            Name = name;
            Code = code;
            Document = document;
            IsActive = isActive;
            Contacts = contacts;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Document { get; set; }
        public bool IsActive { get; set; }
        public List<CreateContactInput> Contacts { get; set; }
    }
}
