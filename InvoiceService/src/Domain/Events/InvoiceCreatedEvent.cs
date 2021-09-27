using InvoiceService.Domain.Common;
using InvoiceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Domain.Events
{
    public class InvoiceCreatedEvent: DomainEvent
    {
        public Invoice Invoice { get; }
        public InvoiceCreatedEvent(Invoice invoice)
        {
            this.Invoice = invoice;
        }
    }
}
