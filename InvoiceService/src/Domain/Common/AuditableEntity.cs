using System;

namespace InvoiceService.Domain.Common
{
    public interface IBaseEntity {
        public Guid Id { get; set; }
    }
    public abstract class AuditableEntity:IBaseEntity
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }
        public Guid Id { get; set; }
    }
}
