using eOrder.Domain.Customers.Entities;

namespace eOrder.Domain.Customers.UseCases.Common
{
    public class CustomerOutput
    {
        public CustomerOutput(
            long id,
            string name, 
            string code, 
            string document, 
            bool isActive, 
            List<ContactOutput> contacts)
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
        public List<ContactOutput> Contacts { get; private set; }

        public static CustomerOutput FromEntity(Customer entity)
        {
            return new CustomerOutput(
                entity.Id,
                entity.Name,
                entity.Code,
                entity.Document,
                entity.IsActive,
                entity.Contacts.Select(c => ContactOutput.FromEntity(c)).ToList());
        }

    }
}
