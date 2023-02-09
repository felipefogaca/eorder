using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Domain.Common.Validation
{
    public abstract class Validator
    {
        protected readonly ValidationHandler _handler;

        protected Validator(ValidationHandler handler)
            => _handler = handler;

        public abstract void Validate();
    }
}
