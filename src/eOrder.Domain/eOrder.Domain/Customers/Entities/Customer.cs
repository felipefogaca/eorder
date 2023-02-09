using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.Validation;

namespace eOrder.Domain.Customers.Entities
{
    public class Customer : AggregateRoot
    {

        
        public Customer(string name, string code, string document, bool isActive)
        {
            Name = name;
            Code = code;
            Document = document;
            Contacts = new List<Contact>();
            IsActive = isActive;

            Validate();
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Document { get; private set; }
        public bool IsActive { get; private set; }
        public List<Contact> Contacts { get; private set; }

        public void Activate()
        {
            IsActive = true;
            Validate();
        }

        public void Deactivate()
        {
            IsActive = false;
            Validate();
        }

        public void Update(
            string name,
            string code, 
            string document)
        {
            Name = name;
            Code = code;
            Document = document;
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        private void Validate()
        {

            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MaxLength(Name, 100, nameof(Name));
            DomainValidation.MinLength(Name, 3, nameof(Name));

            
            DomainValidation.NotNullOrEmpty(Code, nameof(Code));
            DomainValidation.MaxLength(Code, 40, nameof(Code));

            DomainValidation.NotNullOrEmpty(Document, nameof(Document));
            DomainValidation.MaxLength(Document, 20, nameof(Document));

            DomainValidation.NotNull(Contacts, nameof(Contacts));            
        }
    }
}
