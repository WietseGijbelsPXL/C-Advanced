using StudentManager.Application;
using StudentManager.Infrastructure;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StudentService _service;

        public MainWindow()
        {
            InitializeComponent();

            StudentRepository repository = new StudentRepository();
            _service = new StudentService(repository);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _service.AddStudent(firstNameBox.Text, lastNameBox.Text);
                RefreshList();
                MessageBox.Show("Student toegevoegd!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ongeldige invoer", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets mis:\n" + ex.Message, "Onverwachte fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshList()
        {
            studentListBox.ItemsSource = null;
            studentListBox.ItemsSource = _service.GetAllStudents();
        }
    }
}