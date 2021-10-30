using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Commands.CreateInvoice
{
    public class InsertInvoiceLineDto
    {
        public String Item { get; set; }
        public int Quantity { get; set; }
        public Decimal Amount { get; set; }
    }
}
