using eOrder.Domain.Compounds.Entities;

namespace eOrder.Domain.Compounds.UseCases.Common
{
    public class CompoundOutput
    {
        public CompoundOutput(long id, string code, string description, long customerId, bool isActive)
        {
            Id = id;
            Code = code;
            Description = description;
            CustomerId = customerId;
            IsActive = isActive;
        }

        public long Id { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public long CustomerId { get; private set; }
        public bool IsActive { get; private set; }

        public static CompoundOutput FromEntity(Compound entity)
        {
            return new(
                entity.Id, 
                entity.Code, 
                entity.Description, 
                entity.CustomerId, 
                entity.IsActive);
        }
    }
}
