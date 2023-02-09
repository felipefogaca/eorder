using eOrder.Domain.Compounds.UseCases.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Domain.Compounds.UseCases.FindCompound
{
    public interface IFindCompound : IRequestHandler<FindCompoundInput, CompoundOutput>
    {

    }
}
