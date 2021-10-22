using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Commands.UpdateInvoiceLine
{
    public class UpdateInvoiceLineDto
    {
        public Guid Id { get; set; }
        public String Item { get; set; }
        public int Quantity { get; set; }
        public Decimal Amount { get; set; }
    }
}
