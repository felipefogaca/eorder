using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.Validation;
using eOrder.Domain.Exceptions;

namespace eOrder.Domain.Compounds.Entities
{
    public class Compound : AggregateRoot
    {
        public Compound(string code, string description, long customerId, bool isActive, decimal standardQuantity, bool useCustomerMaterial)
        {
            Code = code;
            Description = description;
            CustomerId = customerId;
            IsActive = isActive;
            Parameters = new List<Parameter>();
            StandardQuantity = standardQuantity;
            UseCustomerMaterial = useCustomerMaterial;
            Validate();
        }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public long CustomerId { get; private set; }
        public bool IsActive { get; private set; }
        public decimal StandardQuantity { get; private set; }
        public bool UseCustomerMaterial { get; private set; }
        public List<Parameter> Parameters { get; private set; }

        public void Update(string description, 
            decimal standardQuantity, 
            bool useCustomerMaterial)
        {
            Description = description;
            StandardQuantity = standardQuantity;
            UseCustomerMaterial = useCustomerMaterial;
            Validate();
        }

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

        public void AddParameter(Parameter parameter)
        {
            var alreadyExists = ParameterExists(parameter.RuleId);

            if (alreadyExists)
            {
                throw new EntityValidationException($"{nameof(Parameter)} already exists");
            }

            Parameters.Add(parameter);
        }


        public bool ParameterExists(long ruleId)
        {
            var alreadyExists = Parameters.Any(p => p.RuleId == ruleId);

            return alreadyExists;
        }

        public void RemoveParameter(Parameter parameter)
        {
            Parameters.Remove(parameter);
        }

        private void Validate()
        {
            DomainValidation.NotNullOrEmpty(Code, nameof(Code));
            DomainValidation.MaxLength(Code, 40, nameof(Code));
            DomainValidation.MinLength(Code, 1, nameof(Code));

            DomainValidation.NotNullOrEmpty(Description, nameof(Description));
            DomainValidation.MaxLength(Description, 120, nameof(Description));
            DomainValidation.MinLength(Description, 1, nameof(Description));

            

            DomainValidation.NotNull(Parameters, nameof(Parameters));
        }
    }
}
