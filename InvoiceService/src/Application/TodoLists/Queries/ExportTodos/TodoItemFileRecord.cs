using InvoiceService.Application.Common.Mappings;
using InvoiceService.Domain.Entities;

namespace InvoiceService.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
