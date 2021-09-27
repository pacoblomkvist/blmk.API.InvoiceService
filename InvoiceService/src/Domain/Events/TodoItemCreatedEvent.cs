using InvoiceService.Domain.Common;
using InvoiceService.Domain.Entities;

namespace InvoiceService.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
