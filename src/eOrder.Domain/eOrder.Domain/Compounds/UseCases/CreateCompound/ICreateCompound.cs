using eOrder.Domain.Compounds.UseCases.Common;
using MediatR;

namespace eOrder.Domain.Compounds.UseCases.CreateCompound
{
    public interface ICreateCompound : IRequestHandler<CreateCompoundInput, CompoundOutput>
    {

    }
}
