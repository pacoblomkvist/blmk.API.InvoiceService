using InvoiceService.Domain.Common;
using System.Threading.Tasks;

namespace InvoiceService.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
