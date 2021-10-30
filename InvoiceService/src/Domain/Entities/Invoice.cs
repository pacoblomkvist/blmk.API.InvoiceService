using InvoiceService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceService.Domain.Entities
{
    public class Invoice : AuditableEntity, IHasDomainEvent
    {
        public Invoice()
        {
        }

        public Invoice(Guid? clientId, DateTimeOffset invoiceDate, bool charged, int invoiceNumber, int invoiceYear)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            Number = invoiceNumber;
            InvoiceDate = invoiceDate;
            Charged = charged;
            Year = invoiceYear;
        }
        public Guid? ClientId { get; set; }
        public  String InvoiceNumber
        {
            get => $"{Year}/{Number}";
        }

        public int Number {  get; set; }
        public int Year { get; set; }
        public IEnumerable<InvoiceLines> Lines { get; set; } = new List<InvoiceLines>();
        public DateTimeOffset InvoiceDate { get;  set; }
        public Decimal TotalAmount { get => Lines?.Sum(l => l.TotalEuros)??0; }
        public bool Charged { get;  set; }
        
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

    }
}
