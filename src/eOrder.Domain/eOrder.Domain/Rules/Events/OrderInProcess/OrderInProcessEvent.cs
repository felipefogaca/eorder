using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Customers.Entities;
using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Rules.Entity;
using MediatR;

namespace eOrder.Domain.Rules.Events.OrderInProcess
{
    public class OrderInProcessEvent : INotification
    {
        public OrderInProcessEvent(Order order, Customer customer, Compound compound, List<Rule> rules)
        {
            Order = order;
            Customer = customer;
            Compound = compound;
            Rules = rules;
        }

        public Order Order { get; private set; }
        public Customer Customer { get; set; }
        public Compound Compound { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
