using eOrder.Domain.Compounds.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Compounds.UseCases.CreateCompound
{
    public class CreateCompoundInput : IRequest<CompoundOutput>
    {
        public CreateCompoundInput(string code, string description, long customerId, bool isActive, decimal standardQuantity)
        {
            Code = code;
            Description = description;
            CustomerId = customerId;
            IsActive = isActive;
            StandardQuantity = standardQuantity;
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public long CustomerId { get; set; }
        public bool IsActive { get; set; }
        public decimal StandardQuantity { get; set; }
    }
}
