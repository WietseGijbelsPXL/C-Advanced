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
using VehicleRentalSystem.Application;
using VehicleRentalSystem.Domain;
using VehicleRentalSystem.Infrastructure.Interfaces;
using VehicleRentalSystem.Infrastructure.Repositories;

namespace VehicleRentalSystem.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VehicleService _vehicleService;
        private readonly CustomerService _customerService;
        private readonly RentalService _rentalService;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = "Server=.\\SQLEXPRESS;Database=VehicleRentalDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            DbConnectionFactory dbFactory = new DbConnectionFactory(connectionString);

            IVehicleRepository vehicleRepository = new VehicleRepository(dbFactory);
            ICustomerRepository customerRepository = new CustomerRepository(dbFactory);
            IRentalRepository rentalRepository = new RentalRepository(dbFactory,
                customerRepository, vehicleRepository);

            _vehicleService = new VehicleService(vehicleRepository);
            _customerService = new CustomerService(customerRepository);
            _rentalService = new RentalService(rentalRepository,
                vehicleRepository, customerRepository);

            LoadAllData();
        }

        private async void LoadAllData()
        {
            VehicleDataGrid.ItemsSource = await _vehicleService.GetAllVehiclesAsync();
            RentalDataGrid.ItemsSource = await _rentalService.GetAllRentalsAsync();
            CustomerDataGrid.ItemsSource = await _customerService.GetAllCustomersAsync();
        }

        private async void CreateRentalButton_Click(object sender, RoutedEventArgs e)
        {
            Customer? selectedCustomer = RentalCustomerComboBox.SelectedItem as Customer;
            Vehicle? selectedVehicle = RentalVehicleComboBox.SelectedItem as Vehicle;

            DateTime startDate = StartDatePicker.SelectedDate.Value;
            DateTime endDate = EndDatePicker.SelectedDate.Value;

            try
            {
                await _rentalService.CreateRentalAsync(selectedCustomer.Id,
                    selectedVehicle.Id, startDate, endDate);

                int days = (endDate - startDate).Days;

                // Polymorfisme in actie!
                decimal rentalCost = selectedVehicle.CalculateRentalCost(days);
                decimal insuranceCost = _rentalService.CalculateInsuranceCost(
                    selectedVehicle, days);
                decimal totalCost = rentalCost + insuranceCost;

                string message = $"Verhuring aangemaakt!\n\n" +
                             $"Klant: {selectedCustomer.GetFullName()}\n" +
                             $"Voertuig: {selectedVehicle.Brand} {selectedVehicle.Model}\n" +
                             $"Dagen: {days}\n" +
                             $"Huurkost: {rentalCost:C}\n" +
                             $"Verzekeringskost: {insuranceCost:C}\n" +
                             $"Totale kost: {totalCost:C}";

                MessageBox.Show(message, "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout: {ex.Message}", "Error");
            }
        }

        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshVehiclesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteVehicleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshCustomersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CompleteRentalButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshRentalsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VehicleTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}