using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Orders.Repositories;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.Repositories;
using eOrder.Domain.Rules.RuleEngines;
using MediatR;

namespace eOrder.Domain.Rules.Events.OrderInProcess
{
    public class OrderInProcessHandler : NotificationHandler<OrderInProcessEvent>
    {

        
        private readonly ICompoundsRepository _compoundsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomersRepository _customersRepository;

        public OrderInProcessHandler(ICompoundsRepository compoundsRepository, IOrdersRepository ordersRepository, ICustomersRepository customersRepository)
        {
            
            _compoundsRepository = compoundsRepository;
            _ordersRepository = ordersRepository;
            _customersRepository = customersRepository;
        }

        protected override async void Handle(OrderInProcessEvent notification)
        {

            var factory = new ValidationRuleFactory(_compoundsRepository, _customersRepository, _ordersRepository);

            var order = notification.Order;

            var rules = notification
                .Rules
                .OrderBy(r => r.Index).ToList();

            var rulesToRun = new List<Rule>();

            if(order.RuleId != null)
            {
                var actualRule = rules.First(r => r.Id == order.RuleId);

                foreach(var rule in rules)
                {
                    if(rule.Index >= actualRule.Index)
                        rulesToRun.Add(rule);
                }
            }


            var parameters = notification.Compound.Parameters;

            foreach (var rule in rulesToRun)
            {
                order.ChangeRuleId(rule.Id);

                var parameter = parameters.Where(p => p.RuleId == rule.Id).First();

                var validationRule = factory.Create(rule, parameter);

                var passedInTest = await validationRule.Validate(order);

                if (passedInTest && !string.IsNullOrEmpty(rule.SituationOnApprove))
                {
                    order.ChangeSituation(rule.SituationOnApprove);
                }

                if (!passedInTest && !string.IsNullOrEmpty(rule.SituationOnDisapprove))
                {
                    order.ChangeSituation(rule.SituationOnDisapprove);
                    var activity = new OrderActivity(
                        order.Id,
                        "Info",
                        $"Não passou na regra {rule.Name}",
                        "Sistema",
                        null,
                        DateTime.Now);

                    order.OrderActivities.Add(activity);

                    break;
                }
            };
        }
    }
}
