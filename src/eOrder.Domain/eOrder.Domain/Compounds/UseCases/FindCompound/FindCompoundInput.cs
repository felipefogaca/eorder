using eOrder.Domain.Compounds.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Compounds.UseCases.FindCompound
{
    public class FindCompoundInput : IRequest<CompoundOutput>
    {
        public FindCompoundInput(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
