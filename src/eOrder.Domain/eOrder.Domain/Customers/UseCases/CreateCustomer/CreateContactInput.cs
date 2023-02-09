using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Domain.Customers.UseCases.CreateCustomer
{
    public class CreateContactInput
    {
        public CreateContactInput(string name, string email, bool receiveMail)
        {
            Name = name;
            Email = email;
            ReceiveMail = receiveMail;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public bool ReceiveMail { get; set; }
    }
}
