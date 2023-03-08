using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.BusinessLayer.Services;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        // GET: api/TodoItems   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            var response = await this._todoService.GetTodoItemsAsync();
            return this.Ok(response);  
        }

        // GET: api/TodoItems/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(int id)
        {
            var todoItem = await this._todoService.GetTodoItemAsync(id); 

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        /*
         * Nota come in questa metodo prendiamo in input un oggetto diverso da quello che viene restituito.
         * La proprietà id non è necessario che venga fornita in input sarà il db a generarlo e fornirlo all'utente.
         */
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(TodoItemCreateDto todoItem)
        {
            var itemInsert = await this._todoService.PostTodoItemAsync(todoItem);

            if(itemInsert is not null)
            {
                return CreatedAtAction(
                    nameof(GetTodoItem), 
                    new { id = itemInsert.Id },
                    itemInsert
                );
            }

            return BadRequest();
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id,TodoItemCreateDto todoItem)
        {
            var updateItem = await this._todoService.PutTodoItemAsync(id, todoItem);

            if(updateItem == false)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var isDeleted = await this._todoService.DeleteTodoItemAsync(id);
            if (isDeleted == false)
            {
                return NotFound();
            }            

            return NoContent();
        }
    }
}