using eOrder.Domain.Customers.Entities;

namespace eOrder.Domain.Customers.UseCases.Common
{
    public class ContactOutput
    {
        public ContactOutput(long id, string name, string email, bool receiveMail)
        {
            Id = id;
            Name = name;
            Email = email;
            ReceiveMail = receiveMail;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool ReceiveMail { get; private set; }

        public static ContactOutput FromEntity(Contact entity)
        {
            return new ContactOutput(
                entity.Id,
                entity.Name,
                entity.Email,
                entity.ReceiveMail);
        }
    }
}
