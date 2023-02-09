using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.Validation;
using eOrder.Domain.Exceptions;
using eOrder.Domain.Orders.ValueObjects;

namespace eOrder.Domain.Orders.Entities
{
    public class Order : AggregateRoot
    {

        public Order( string requestNumber, long customerId, string customerName, long compoundId, string compoundCode, string compoundDescription, Release release, Release releaseFinal, string orderType, DateTime shippingDate, string? purchaseOrder, string orderSituation, decimal standardQuantity, long? ruleId) 
            
        {
            RequestNumber = requestNumber;
            CustomerId = customerId;
            CustomerName = customerName;
            CompoundId = compoundId;
            CompoundCode = compoundCode;
            CompoundDescription = compoundDescription;
            Release = release;
            ReleaseFinal = releaseFinal;
            OrderType = orderType;
            ShippingDate = shippingDate;
            PurchaseOrder = purchaseOrder;
            ReleaseHistories = new List<ReleaseHistory>();
            OrderActivities = new List<OrderActivity>();
            OrderSituation = orderSituation;
            StandardQuantity = standardQuantity;
            RuleId = ruleId;

            Validate();
        }

        public string RequestNumber { get; private set; }
        public long CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public long CompoundId { get; private set; }
        public string CompoundDescription { get; private set; }
        public string CompoundCode { get; private set; }
        public DateTime ShippingDate { get; set; }


        public Release Release { get; private set; }
        public Release ReleaseFinal { get; private set; }
        public string OrderType { get; private set; }
        
        public string? PurchaseOrder { get; private set; }
        public List<ReleaseHistory> ReleaseHistories { get; private set; }
        public List<OrderActivity> OrderActivities { get; private set; }
        

        public string OrderSituation { get; private set; }
        public decimal StandardQuantity { get; private set; }
        public long? RuleId { get; private set; }


        public void Update(
            Release release,
            string orderType)
        {
            if(ShippingDate <= DateTime.Now)
                throw new EntityValidationException("It is not possible to update the order on the same day or after the delivery date");

            if(release.Number == -1 
                && release.Quantity != Release.Quantity)
            {
                Release = release;
                OrderType = orderType;

                if (OrderType == Type.Firm)
                    OrderSituation = Situation.Processing;
            }
            
            if(release.Number > Release.Number)
            {
                if (release.Quantity != Release.Quantity
                    && orderType == Type.Firm)
                    OrderSituation = Situation.Processing;

                Release = release;
                OrderType = orderType;
            }


            Validate();
        }

        public void ChangeReleaseFinal(Release releaseFinal)
        {
            ReleaseFinal = releaseFinal;

            Validate();
        }

        public void ChangeRuleId(long ruleId)
        {
            RuleId = ruleId;
            Validate();
        }

        public void ChangePurchaseOrder(string purchaseOrder)
        {
            PurchaseOrder = purchaseOrder;
            Validate();
        }

        public void ChangeSituation(string situation)
        {
            OrderSituation = situation;
            Validate();
        }

        private void Validate()
        {
            DomainValidation.NotNullOrEmpty(RequestNumber, nameof(RequestNumber));
            DomainValidation.MinLength(RequestNumber, 1, nameof(RequestNumber));
            DomainValidation.MaxLength(RequestNumber, 40, nameof(RequestNumber));

            DomainValidation.NotNullOrEmpty(CustomerName, nameof(CustomerName));
            DomainValidation.NotNullOrEmpty(CompoundDescription, nameof(CompoundDescription));

            DomainValidation.NotNullOrEmpty(OrderType, nameof(OrderType));

            var orderTypeExists = OrderTypes.Any(o => o == OrderType);
            if (!orderTypeExists)
                throw new EntityValidationException($"{nameof(OrderType)} {OrderType} not exists");

            DomainValidation.NotNullOrEmpty(OrderSituation, nameof(OrderSituation));
            var situationExists = Situations.Any(s => s == OrderSituation);
            if (!situationExists)
                throw new EntityValidationException($"{nameof(OrderSituation)} {OrderSituation} not exists");

            if (StandardQuantity <= 0)
                throw new EntityValidationException($"{nameof(StandardQuantity)} should be greater or equal 0");


        }


        public static readonly IReadOnlyCollection<string> Situations = new List<string>()
        {
            "Aprovado",
            "Reprovado",
            "Cancelamento",
            "Cancelado",
            "Cancelar",
            "Futuro",
            "Analise",
            "Finalizado",
            "Erro",
            "Processando",
            "Aguardando",
            "Quantidade"
        };

        public static readonly IReadOnlyCollection<string> OrderTypes = new List<string>()
        {
            "Firme",
            "Futuro"
        };

        public static class Situation
        {
            public const string Approved = "Aprovado";
            public const string Disapproved = "Reprovado";
            public const string Cancellation = "Cancelamento";
            public const string Canceled = "Cancelado";
            public const string Cancel = "Cancelar";
            public const string Future = "Futuro";
            public const string Analyze = "Analise";
            public const string Finished = "Finalizado";
            public const string Error = "Erro";
            public const string Processing = "Processando";
            public const string Waiting = "Aguardando";
            public const string Quantity = "Quantidade";
        }

        public static class Type
        {
            public const string Firm = "Firme";
            public const string Future = "Futuro";
        }
    }
}
