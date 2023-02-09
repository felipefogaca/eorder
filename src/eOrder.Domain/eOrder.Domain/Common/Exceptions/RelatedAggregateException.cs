﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Domain.Common.Exceptions
{
    public class RelatedAggregateException : ApplicationException
    {
        public RelatedAggregateException(string? message) : base(message)
        { }
    }
}
