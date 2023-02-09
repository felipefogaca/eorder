using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Domain.Common.Validation
{
    public class NotificationValidationHandler : ValidationHandler
    {
        private readonly List<ValidationError> _errors;

        public NotificationValidationHandler()
            => _errors = new List<ValidationError>();

        public IReadOnlyCollection<ValidationError> Errors
            => _errors.AsReadOnly();

        public bool HasErrors() => _errors.Count > 0;

        public override void HandleError(ValidationError error)
            => _errors.Add(error);
    }
}
