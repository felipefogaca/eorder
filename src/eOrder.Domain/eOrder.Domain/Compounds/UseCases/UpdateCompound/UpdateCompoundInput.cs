using MediatR;

namespace eOrder.Domain.Compounds.UseCases.UpdateCompound
{
    public class UpdateCompoundInput : IRequest
    {
        public UpdateCompoundInput(long id, string code, string description, Guid customerId, bool isActive)
        {
            Id = id;
            Description = description;
            IsActive = isActive;
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
