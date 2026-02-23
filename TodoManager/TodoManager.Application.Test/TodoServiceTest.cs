using TodoManager.Application.Services;
using TodoManager.Domain.Models;

namespace TodoManager.Application.Test
{
    public class TodoServiceTest
    {
        [Fact]
        public void AddTodo_DuplicateTitle_ThrowsInvalidOperationException()
        {
            // Arrange
            TodoService service = new TodoService();

            service.AddTodo("Buy milk", null, DateTime.Today.AddDays(1));

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                service.AddTodo("  BUY MILK  ", "Duplicate", DateTime.Today.AddDays(2));
            });
        }

        [Fact]
        public void DeleteTodo_PastDueDate_ThrowsInvalidOperationException()
        {
            // Arrange
            TodoService service = new TodoService();

            service.AddTodo("Old task", null, DateTime.Today.AddDays(-1));

            var todos = service.GetTodos();
            var todoToDelete = todos[0];

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                service.DeleteTodo(todoToDelete);
            });
        }

        [Fact]
        public void DeleteTodo_CompletedTodo_ThrowsInvalidOperationException()
        {
            // Arrange
            TodoService service = new TodoService();

            service.AddTodo("Finish assignment", null, DateTime.Today.AddDays(2));

            var todos = service.GetTodos();
            var todo = todos[0];

            service.CompleteTodo(todo);

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                service.DeleteTodo(todo);
            });
        }

        [Fact]
        public void CompleteTodo_SetsCompletedAt()
        {
            // Arrange
            TodoService service = new TodoService();

            service.AddTodo("Read chapter", null, DateTime.Today.AddDays(3));

            var todos = service.GetTodos();
            var todo = todos[0];

            // Act
            service.CompleteTodo(todo);

            // Assert
            Assert.True(todo.IsCompleted);
            Assert.NotNull(todo.CompletedAt);
        }

        [Fact]
        public void AddTodo_EmptyTitle_ThrowsArgumentNullException()
        {
            TodoService todoService = new TodoService();

            Assert.Throws<ArgumentNullException>(() => todoService.AddTodo("", null, DateTime.Today.AddDays(1)));
        }

        [Fact]
        public void DeleteTodo_ValidTodo_DeletesTodo()
        {
            TodoService todoService = new TodoService();

            todoService.AddTodo("Title", null, DateTime.Today.AddDays(1));

            TodoItem todoItem = todoService.GetTodos()[0];
            
            todoService.DeleteTodo(todoItem);

            Assert.Equal(0,todoService.GetTodos().Count);
        }

        [Fact]
        public void MarkAsCompleted_Twice_NoError()
        {
            TodoService todoService = new TodoService();

            todoService.AddTodo("Read chapter", null, DateTime.Today.AddDays(3));

            var todos = todoService.GetTodos();
            var todo = todos[0];

            todoService.CompleteTodo(todo);

            Assert.ThrowsAny<Exception>(() =>
            {
                todoService.CompleteTodo(todo);
            });
        }
    }
}