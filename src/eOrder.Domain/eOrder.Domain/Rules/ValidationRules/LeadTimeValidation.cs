using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Orders.Repositories;
using eOrder.Domain.Rules.Entity;

namespace eOrder.Domain.Rules.ValidationRules
{
    public class LeadTimeValidation : ValidationRule
    {

        public const int Code = 1;
        public const string Interval = "Interval";
        public const string Value = "Value";

        public LeadTimeValidation(Rule rule, Parameter parameter, ICompoundsRepository compoundsRepository, ICustomersRepository customersRepository, IOrdersRepository ordersRepository) 
            : base(rule, parameter, compoundsRepository, customersRepository, ordersRepository) { }

        public override int GetCode()
        {
            return Code;
        }

        public override async Task<bool> Validate(Order order)
        {
            var today = DateTime.Now.Date;
            var shippingDate = order.ShippingDate;


            var days = (shippingDate - today).TotalDays;

            var passedTheTest = false;

            if (_rule.ParameterOption == Interval)
            {
                var startInterval = Convert.ToInt32(_parameter.Value);
                var endInterval = Convert.ToInt32(_parameter.ValueTwo);

                passedTheTest = days >= startInterval && days <= endInterval;
            }

            if(_rule.ParameterOption == Value)
            {
                var parameterDay = Convert.ToInt32(_parameter.Value);
                var comparator = _parameter.Comparator;

                if (comparator == ">=")
                    passedTheTest = days >= parameterDay;
                else if (comparator == ">")
                    passedTheTest = days > parameterDay;
                else if (comparator == "=")
                    passedTheTest = days == parameterDay;
                else if (comparator == "<=")
                    passedTheTest = days <= parameterDay;
                else
                    passedTheTest = days < parameterDay;
            }

            if (passedTheTest && string.IsNullOrWhiteSpace(_rule.SituationOnApprove))
                order.ChangeSituation(_rule.SituationOnApprove);
            else if (!passedTheTest && string.IsNullOrEmpty(_rule.SituationOnDisapprove))
                order.ChangeSituation(_rule.SituationOnDisapprove);



            return await Task.FromResult(passedTheTest);
        }
    }
}
