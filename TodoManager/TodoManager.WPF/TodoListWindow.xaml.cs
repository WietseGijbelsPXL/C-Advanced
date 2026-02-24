using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TodoManager.Application.Services;
using TodoManager.Domain.Models;

namespace TodoManager.WPF
{
    /// <summary>
    /// Interaction logic for TodoListWindow.xaml
    /// </summary>
    public partial class TodoListWindow : Window
    {
        private readonly TodoService _todoService;

        public TodoListWindow()
        {
            InitializeComponent();

            _todoService = new TodoService();
            RefreshTodos();
        }

        public void RefreshTodos()
        {
            TodosListBox.Items.Clear();

            foreach (TodoItem todoItem in _todoService.GetTodos())
            {
                TodosListBox.Items.Add(todoItem);
            }

            ClearDetails();
        }

        public void ClearDetails()
        {
            TitleTextBlock.Text = string.Empty;
            DueDateTextBlock.Text = string.Empty;
            CompletedTextBlock.Text = string.Empty;
            CompletedAtTextBlock.Text = string.Empty;
            DescriptionTextBlock.Text = string.Empty;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTodoWindow addTodoWindow = new AddTodoWindow();
            addTodoWindow.Owner = this;

            if (addTodoWindow.ShowDialog() != true)
            {
                return;
            }
            try
            {
                _todoService.AddTodo(addTodoWindow.TodoTitle, addTodoWindow.TodoDescription, addTodoWindow.TodoDueDate);
                RefreshTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItem todoItem = (TodoItem)TodosListBox.SelectedItem;

            if (todoItem == null)
            {
                MessageBox.Show("Er is geen item geselecteerd.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    _todoService.CompleteTodo(todoItem);
                    RefreshTodos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItem todoItem = (TodoItem)TodosListBox.SelectedItem;

            if (todoItem == null)
            {
                MessageBox.Show("Er is geen item geselecteerd.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    _todoService.DeleteTodo(todoItem);
                    RefreshTodos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodos();
        }

        private void TodosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TodoItem todoItem = (TodoItem)TodosListBox.SelectedItem;

            if (todoItem == null)
            {
                ClearDetails();
                return;
            }
            TitleTextBlock.Text = todoItem.Title;
            DueDateTextBlock.Text = todoItem.DueDate.ToString();
            CompletedTextBlock.Text = todoItem.IsCompleted.ToString();
            CompletedAtTextBlock.Text = todoItem.CompletedAt.ToString();
            DescriptionTextBlock.Text = todoItem.Description;

            RefreshTodos();
        }
    }
}
