using InvoiceService.Domain.Common;
using InvoiceService.Domain.Entities;

namespace InvoiceService.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
