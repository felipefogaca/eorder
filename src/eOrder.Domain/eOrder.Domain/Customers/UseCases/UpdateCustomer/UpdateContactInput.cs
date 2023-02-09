namespace eOrder.Domain.Customers.UseCases.UpdateCustomer
{
    public class UpdateContactInput
    {
        public UpdateContactInput(long id, string name, string email, bool receiveMail)
        {
            Id = id;
            Name = name;
            Email = email;
            ReceiveMail = receiveMail;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool ReceiveMail { get; set; }
    }
}
