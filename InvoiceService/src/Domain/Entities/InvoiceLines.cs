using InvoiceService.Domain.Common;
using InvoiceService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Domain.Entities
{
    public class InvoiceLines : AuditableEntity
    {
       public Guid InvoiceId { get; set; }
        public String Item { get; set; }
        public int _quantity;
        public int Quantity { get => _quantity ; set{
                if (value <= 0)
                {
                    throw new LessThanZeroException(value);
                }
                _quantity = value;
            } }
        public Decimal Amount { get; set; }
        public Decimal TotalEuros { get => Amount * Quantity; }
    }
}
