using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManager.Domain.Models;
using TodoManager.Infrastructure.Repositories;

namespace TodoManager.Application.Services
{
    public class TodoService
    {
        private readonly TodoRepository _repository;

        public TodoService()
        {
            _repository = new TodoRepository();
        }

        public List<TodoItem> GetTodos()
        {
            return _repository.GetAll();
        }

        public void AddTodo(string title, string? description, DateTime dueDate)
        {
            TodoItem? duplicate = _repository.GetAll().Find(todo => todo.Title.Equals(title.Trim(), StringComparison.OrdinalIgnoreCase));
            if (duplicate != null)
            {
                throw new InvalidOperationException("De titel moet uniek zijn");
            }

            _repository.Add(new TodoItem(title, description, dueDate));
        }

        public void CompleteTodo(TodoItem todoItem)
        {
            _repository.Get(todoItem.Id).MarkAsCompleted();
        }

        public void DeleteTodo(TodoItem todoItem)
        {
            if (todoItem.DueDate.Date < DateTime.Today)
            {
                throw new InvalidOperationException("De dueDqte is verlopen.");
            }

            if (todoItem.IsCompleted)
            {
                throw new InvalidOperationException("Het todo item is al complete.");
            }

            _repository.Remove(todoItem);
        }
    }
}
