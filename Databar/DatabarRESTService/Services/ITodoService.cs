using System.Collections.Generic;
using TodoRESTService.Models;

namespace DatabarRESTService.Services
{
    public interface ITodoService
    {
        bool DoesItemExist(string id);
        TodoItem Find(string id);
        IEnumerable<TodoItem> GetData();
        void InsertData(TodoItem item);
        void UpdateData(TodoItem item);
        void DeleteData(string id);
    }
}
