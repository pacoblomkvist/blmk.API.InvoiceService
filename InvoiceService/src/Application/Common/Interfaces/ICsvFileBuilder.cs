using InvoiceService.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace InvoiceService.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
