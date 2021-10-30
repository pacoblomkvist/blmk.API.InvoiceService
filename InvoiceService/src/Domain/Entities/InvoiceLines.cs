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
        InvoiceLines()
        {
        }

        public InvoiceLines(int quantity, Guid invoiceId, string item, decimal amount)
        {
            Quantity = quantity;
            InvoiceId = invoiceId;
            Item = item;
            Amount = amount;
        }
        public Guid InvoiceId { get; set; }
        public String Item { get; set; }
        public int Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Decimal TotalEuros { get => Amount * Quantity; }

        
    }
}
