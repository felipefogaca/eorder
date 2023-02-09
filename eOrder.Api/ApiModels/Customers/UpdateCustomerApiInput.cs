using eOrder.Domain.Customers.UseCases.UpdateCustomer;

namespace eOrder.Api.ApiModels.Customers
{
    public class UpdateCustomerApiInput
    {
        public UpdateCustomerApiInput(string name, string code, string document, bool isActive, List<UpdateContactInput> contacts)
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
        public List<UpdateContactInput> Contacts { get; set; }
    }
}
