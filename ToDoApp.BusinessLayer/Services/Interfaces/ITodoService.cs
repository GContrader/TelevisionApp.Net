using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;

namespace ToDoApp.BusinessLayer.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync();
        Task<TodoItemDto> GetTodoItemAsync(int id);
        Task<TodoItemDto> PostTodoItemAsync(TodoItemCreateDto todoItem);
        Task<bool> PutTodoItemAsync(int id, TodoItemCreateDto todoItem);
        Task<bool> DeleteTodoItemAsync(int id);
    }
}