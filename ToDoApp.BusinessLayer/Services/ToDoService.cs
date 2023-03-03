using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.DataAccessLayer;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Services
{
    public class ToDoService: ITodoService
    {
        private readonly IMapper _mapper;
        private readonly TodoappContext _db;

        public ToDoService(IMapper mapper, TodoappContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var todoItem = await _db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return false;
            }

            this._db.TodoItems.Remove(todoItem);
            await this._db.SaveChangesAsync();

            return true;
        }

        public async Task<TodoItemDto> GetTodoItemAsync(int id)
        {
            var todoItem = await this._db.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            return this._mapper.Map<TodoItemDto>(todoItem);
        }

        public async Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync()
        {
            return await this._db.TodoItems
                    .OrderByDescending(item => item.LastModified)
                    .ProjectTo<TodoItemDto>(this._mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<TodoItemDto> PostTodoItemAsync(TodoItemCreateDto itemDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = itemDTO.IsComplete,
                Name = itemDTO.Title,
                LastModified = DateTime.Now
            };

            this._db.TodoItems.Add(todoItem);
            var isDone = await this._db.SaveChangesAsync();

            if(isDone > 0)
            {
                return this._mapper.Map<TodoItemDto>(todoItem);
            } 
            
            return null;
        }

        public async Task<bool> PutTodoItemAsync(int id, TodoItemCreateDto todoItem)
        {
            var item = await this._db.TodoItems.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            item.Name = todoItem.Title;
            item.IsComplete = todoItem.IsComplete;
            item.LastModified = DateTime.Now;

            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return true;
            }

            return false;
        }
    }
}
