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

namespace TodoManager.WPF
{
    /// <summary>
    /// Interaction logic for AddTodoWindow.xaml
    /// </summary>
    public partial class AddTodoWindow : Window
    {
        public string TodoTitle { get; private set; } = " ";
        public string? TodoDescription { get; private set; }
        public DateTime TodoDueDate { get; private set; }

        public AddTodoWindow()
        {
            InitializeComponent();

            DueDatePicker.SelectedDate = DateTime.Now;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TodoTitle = TitleTextBox.Text;
            TodoDescription = DescriptionTextBox.Text;
            TodoDueDate = DueDatePicker.SelectedDate!.Value;

            DialogResult = true;
            Close();
        }
    }
}
