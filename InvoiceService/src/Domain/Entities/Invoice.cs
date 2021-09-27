using InvoiceService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Domain.Entities
{
    public class Invoice : AuditableEntity, IHasDomainEvent
    {
        public Guid? ClientId { get; set; }
        public IList<InvoiceLines> Lines { get; set; } = new List<InvoiceLines>();
        public DateTimeOffset? InvoiceDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public bool Charged { get; set; }
        
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
