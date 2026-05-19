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

using DevShelf.Application;
using DevShelf.Application.Models;
using DevShelf.Infrastructure;
using System.Windows;
using System.Windows.Controls;

namespace DevShelf.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookService _bookService;
        BookRequest _bookRequest;
        BookResult _bookResult;

        public MainWindow()
        {
            InitializeComponent();

            _bookService = new BookService(new BookRepository());
            _bookRequest = new BookRequest
            {
                Page = 1,
                BooksPerPage = 10,
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAuthors();
            LoadBooks();
        }

        #region Sort
        private void sortYearAscButton_Click(object sender, RoutedEventArgs e)
        {
            _bookRequest.OrderBy = "Year";
            _bookRequest.OrderDirection = "asc";
            LoadBooks();
        }

        private void sortTitleDescButton_Click(object sender, RoutedEventArgs e)
        {
            _bookRequest.OrderBy = "Title";
            _bookRequest.OrderDirection = "desc";
            LoadBooks();
        }

        private void sortTitleAscButton_Click(object sender, RoutedEventArgs e)
        {
            _bookRequest.OrderBy = "Title";
            _bookRequest.OrderDirection = "asc";
            LoadBooks();
        }
        #endregion
        private void titleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _bookRequest.TitleFilter = titleTextBox.Text;
        }

        private void authorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (authorComboBox.SelectedIndex == -1)
            {
                _bookRequest.AuthorFilter = "";
            }
            else
            {
                _bookRequest.AuthorFilter = authorComboBox.SelectedValue.ToString()!;
                //NOTE: het uitroepteken achteraan zegt tegen de compiler dat deze waarde niet null is
            }
        }

        private void ratingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _bookRequest.RatingFilter = (double)ratingSlider.Value;
        }

        private void clearFilterButton_Clicked(object sender, RoutedEventArgs e)
        {
            titleTextBox.Clear();
            authorComboBox.SelectedIndex = -1;
            ratingSlider.Value = 0;
            itemsPerPageTextBox.Text = "10";
            LoadBooks();
        }

        private void applyFilterButton_Clicked(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }

        private void firstPageButton_Click(object sender, RoutedEventArgs e)
        {
            _bookRequest.Page = 1;
            LoadBooks();
        }

        private void previousPageButton_Click(object sender, RoutedEventArgs e)
        {
            _bookRequest.Page--;
            LoadBooks();
        }

        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _bookRequest.Page++;
            LoadBooks();
        }

        private void lastPageButton_Click(object sender, RoutedEventArgs e)
        {
            _bookRequest.Page = _bookResult.TotalPages;
            LoadBooks();
        }

        private void LoadBooks()
        {
            _bookResult = _bookService.GetBooks(_bookRequest);

            booksDataGrid.ItemsSource = _bookResult.Books;

            //TODO: Show pagination info
            pageTextBlock.Text = $"{_bookResult.CurrentPage}/{_bookResult.TotalPages}";

            nextPageButton.IsEnabled = lastPageButton.IsEnabled = _bookResult.CurrentPage != _bookResult.TotalPages;
            firstPageButton.IsEnabled = previousPageButton.IsEnabled = _bookResult.CurrentPage != 1;
        }

        private void LoadAuthors()
        {
            authorComboBox.ItemsSource = _bookService.GetAllAuthors();
        }

        private void itemsPerPageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _bookRequest.BooksPerPage = int.Parse(itemsPerPageTextBox.Text);
        }
    }
}