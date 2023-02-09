using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Domain.Common.Validation
{
    public abstract class ValidationHandler
    {
        public abstract void HandleError(ValidationError error);

        public void HandleError(string message)
            => HandleError(new ValidationError(message));
    }
}
