using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceDto
    {
        public CreateInvoiceDto()
        {
            lines = new List<InsertInvoiceLineDto>();
        }
        public Guid? ClientId { get; set; }
        public IEnumerable<InsertInvoiceLineDto> lines { get; set; }
        public DateTimeOffset? InvoiceDate { get; set; }
    }
}
