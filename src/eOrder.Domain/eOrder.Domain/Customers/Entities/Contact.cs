using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.Validation;

namespace eOrder.Domain.Customers.Entities
{
    public class Contact : AggregateRoot
    {
        public Contact(string name, string email, bool receiveMail, long customerId)
        {
            Name = name;
            Email = email;
            ReceiveMail = receiveMail;
            CustomerId = customerId;
            Validate();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool ReceiveMail { get; private set; }
        public long CustomerId { get; private set; }

        public void Update(
            string name,
            string email,
            bool receiveMail)
        {
            Name = name;
            Email = email;
            ReceiveMail = receiveMail;

            Validate();

        }

        public void ActivateReceiveMail()
        {
            ReceiveMail = true;
            Validate();
        }

        public void DeactivateReceiveMail()
        {
            ReceiveMail = true;
            Validate();
        }

        private void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 3, nameof(Name));
            DomainValidation.MaxLength(Name, 100, nameof(Name));

            DomainValidation.NotNullOrEmpty(Email, nameof(Email));
            DomainValidation.MinLength(Email, 4, nameof(Email));
            DomainValidation.MaxLength(Email, 255, nameof(Email));
        }
    }
}
