using HttpClientDemo.Application;
using HttpClientDemo.Domain;
using HttpClientDemo.Domain.Models;
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
        DogService _dogService;

        public MainWindow()
        {
            InitializeComponent();
            _dogService = new DogService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _dogService.InnitializeAsync();
            breedComboBox.ItemsSource = _dogService.Dogs;
            await LoadNextDog();
        }

        private async Task LoadNextDog()
        {
            string imgurl = await _dogService.GetNextDogImageAsync();
            dogImage.Source = new BitmapImage(new Uri(imgurl));
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            if (_dogService.Guess((Dog)breedComboBox.SelectedItem))
            {
                feedbackTextBlock.Text = "Juist";
            }
            else
            {
                feedbackTextBlock.Text = $"Fout, juiste ras is {_dogService.CurrentDog}";
            }
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadNextDog();
        }
    }
}