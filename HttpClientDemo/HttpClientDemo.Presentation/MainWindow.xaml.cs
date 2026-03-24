using HttpClientDemo.Application;
using HttpClientDemo.Domain;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HttpClientDemo.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DogService _service;

        public MainWindow()
        {
            InitializeComponent();
            _service = new DogService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _service.GetAll();
            await _service.GetRandomImageSouce();
            breedComboBox.ItemsSource = _service.Dogs;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}