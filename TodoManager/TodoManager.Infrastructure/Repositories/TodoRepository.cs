using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManager.Domain.Models;

namespace TodoManager.Infrastructure.Repositories
{
    public class TodoRepository
    {
        private readonly List<TodoItem> _todos;

        public TodoRepository()
        {
            _todos = new List<TodoItem>();
        }

        public List<TodoItem> GetAll()
        {
            return new List<TodoItem>(_todos);
        }

        public TodoItem Get(int id)
        {
            return _todos.Find(todo => todo.Id == id);
        }

        public void Add(TodoItem todoItem)
        {
            todoItem.Id = _todos.Count + 1;
            _todos.Add(todoItem);
        }

        public bool Remove(TodoItem todoItem)
        {
            return _todos.Remove(todoItem);
        }
    }
}
