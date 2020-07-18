using Assets.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Assets.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
