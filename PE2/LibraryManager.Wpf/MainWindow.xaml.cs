using LibraryManager.Domain.Common;
using LibraryManager.Domain.Common;
using LibraryManager.Domain.Entities;
using LibraryManager.Infrastructure.Clients;
using LibraryManager.Infrastructure.Repositories;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibraryManager.Application.Services;
using LibraryManager.Application.Abstractions;

namespace LibraryManager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LibraryService _libraryService;
        private readonly MemberService _memberService;

        public MainWindow()
        {
            InitializeComponent();

            //TODO: Initialize services with their dependencies
            ILibraryItemRepository libraryItemRepository = new ItemRepository();
            IBookApiClient bookApiClient = new BookApiClient();

            _libraryService = new LibraryService(libraryItemRepository, bookApiClient);

            IMemberRepository memberRepository = new MemberRepository();

            _memberService = new MemberService(memberRepository);
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            LoadLibraryItems();
            LoadMembers();
        }

        private void LoadLibraryItems(LibraryItem itemToSelect = null)
        {
            //TODO: Use LibraryService to get all items and set as ItemsSource for libraryItemsListBox
            libraryItemsListBox.ItemsSource = _libraryService.GetAllItems();


            //TODO: If not null, set the itemToSelect as the selected item in the listbox and scroll it into view.
            //TIP: myListBox.ScrollIntoView(...)
            if(itemToSelect != null)
            {
                libraryItemsListBox.SelectedItem = itemToSelect;
                libraryItemsListBox.ScrollIntoView(itemToSelect);
            }

        }

        private void LoadMembers()
        {
            //TODO: Use MemberService to get all members and set as ItemsSource for memberComboBox
            memberComboBox.ItemsSource = _memberService.GetAllMembers();

        }

        private void OnLibraryItemsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Call DisplayItemDetails + DisplayLoanableInfo OR ClearItemDetails when no item is selected
            if(libraryItemsListBox.SelectedItem == null)
            {
                ClearItemDetails();
            }
            else
            {
                DisplayItemDetails((LibraryItem)libraryItemsListBox.SelectedItem);
                DisplayLoanableInfo((LibraryItem)libraryItemsListBox.SelectedItem);
            }
        }

        private void DisplayLoanableInfo(LibraryItem selectedItem)
        {
            //TODO: Call UpdateLoanStatus() and enable/disable loan/return buttons accordingly.
            // Or if the item is not loanable, show "This item cannot be loaned" in the loanStatusTextBox and disable memberComboBox and buttons.
            if(selectedItem is ILoanable && ((ILoanable)selectedItem).IsAvailable)
            {
                UpdateLoanStatus((ILoanable)selectedItem);
                loanButton.IsEnabled = true;
                returnButton.IsEnabled = false;
            } else if(selectedItem is ILoanable && !((ILoanable)selectedItem).IsAvailable)
            {
                UpdateLoanStatus((ILoanable)selectedItem);
                loanButton.IsEnabled = false;
                returnButton.IsEnabled = true;
            }
            else
            {
                loanStatusTextBox.Text = "This item cannot be loaned";
                memberComboBox.IsEnabled = loanButton.IsEnabled = returnButton.IsEnabled = false;
            }

        }

        private void UpdateLoanStatus(ILoanable loanable)
        {
            //TODO: Update the loanStatusTextBox to show if the item is available or who it's loaned to, and enable/disable the memberComboBox accordingly.
            if (loanable.IsAvailable)
            {
                loanStatusTextBox.Text = "Available";
                memberComboBox.IsEnabled = true;
            }
            else
            {
                loanStatusTextBox.Text = loanable.LoanedBy;
                memberComboBox.IsEnabled = false;
            }
        }

        private void DisplayItemDetails(LibraryItem item)
        {
            // Hide all property grids first
            commonPropertiesGrid.Visibility = Visibility.Collapsed;
            bookPropertiesGrid.Visibility = Visibility.Collapsed;
            gamePropertiesGrid.Visibility = Visibility.Collapsed;
            magazinePropertiesGrid.Visibility = Visibility.Collapsed;

            // Show and populate common properties
            commonPropertiesGrid.Visibility = Visibility.Visible;
            titleTextBox.Text = item.Title;
            yearTextBox.Text = item.Year.ToString();
            genreTextBox.Text = item.Genre;
            locationTextBox.Text = item.Location;

            //TODO: Show and populate type-specific properties based on the actual type of the item (Book, Game, Magazine)
            if(item is Book)
            {
                bookPropertiesGrid.Visibility = Visibility.Visible;
                authorTextBox.Text = ((Book)item).Author;
                isbnTextBox.Text = ((Book)item).Isbn;
            }
            if (item is Game)
            {
                gamePropertiesGrid.Visibility = Visibility.Visible;
                platformTextBox.Text = ((Game)item).Platform;
                pegiTextBox.Text = ((Game)item).Pegi.ToString();
            }
            if(item is Magazine)
            {
                magazinePropertiesGrid.Visibility = Visibility.Visible;
                issueNumberTextBox.Text = ((Magazine)item).IssueNumber.ToString();
            }
          
        }



        private void ClearItemDetails()
        {
            // Hide all property grids
            commonPropertiesGrid.Visibility = Visibility.Collapsed;
            bookPropertiesGrid.Visibility = Visibility.Collapsed;
            gamePropertiesGrid.Visibility = Visibility.Collapsed;
            magazinePropertiesGrid.Visibility = Visibility.Collapsed;

            // Clear all textboxes
            titleTextBox.Text = string.Empty;
            yearTextBox.Text = string.Empty;
            genreTextBox.Text = string.Empty;
            locationTextBox.Text = string.Empty;
            authorTextBox.Text = string.Empty;
            isbnTextBox.Text = string.Empty;
            platformTextBox.Text = string.Empty;
            pegiTextBox.Text = string.Empty;
            issueNumberTextBox.Text = string.Empty;

            loanStatusTextBox.Text = string.Empty;
            loanStatusTextBox.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            loanButton.IsEnabled = false;
            returnButton.IsEnabled = false;
        }

        private void OnLoanButtonClicked(object sender, RoutedEventArgs e)
        {
            //TODO: Use LibraryService to loan the selected item to the selected member, then refresh the item details to show updated loan status and enable/disable buttons accordingly.
            _libraryService.LoanItem(((LibraryItem)libraryItemsListBox.SelectedItem).Id,(Member)memberComboBox.SelectedItem, DateTime.Now);
            UpdateLoanStatus((ILoanable)libraryItemsListBox.SelectedItem);
        }

        private void OnReturnButtonClicked(object sender, RoutedEventArgs e)
        {
            //TODO: Use LibraryService to return the selected item, then refresh the item details to show updated loan status and enable/disable buttons accordingly.
            //      Make sure to confirm the return action with the user before proceeding.
            ILoanable loanedItem = (ILoanable)libraryItemsListBox.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Return item loaned by {(loanedItem).LoanedBy}", "Confirm Return", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                _libraryService.ReturnItem(((LibraryItem)loanedItem).Id);
                UpdateLoanStatus(loanedItem);
            }
        }

        private async void OnAddBookButtonClicked(object sender, RoutedEventArgs e)
        {
            Book newBook;

            //TODO: Use LibraryService to get book details from OpenLibrary API using the ISBN from newBookIsbnTextBox, then add it to the library and refresh the list.
            //
            //Use one of the following ISBN codes to test:
            //1. 9780439023481
            //2. 9780547928227
            //3. 9780307474278
            //4. 9780061122415

            newBook = await _libraryService.CreateBookFromOpenLibraryAsync(isbnTextBox.Text, locationTextBox.Text);
            _libraryService.AddItem(newBook);

            LoadLibraryItems(newBook);

            newBookIsbnTextBox.Clear();
            newBookLocationTextBox.Clear();
        }


    }
}