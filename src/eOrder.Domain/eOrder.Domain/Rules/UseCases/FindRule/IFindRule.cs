using eOrder.Domain.Rules.UseCases.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Domain.Rules.UseCases.FindRule
{
    public interface IFindRule : IRequestHandler<FindRuleInput, RuleOutput>
    {

    }
}
