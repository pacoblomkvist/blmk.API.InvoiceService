using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Domain.Exceptions
{
    public class LessThanZeroException: Exception
    {
        public LessThanZeroException(int integer)
          : base($"The value need to be greater than 0. {integer} not supported")
        {
        }
    }
}
