using HexiSure.Application.Services;
using HexiSure.Domain.Insurables;
using HexiSure.Domain.Insurances;
using HexiSure.Infrastructure.Data;
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
using System.Windows.Threading;
//using HexiSureClassLibrary.DataAccess;
//using HexiSureClassLibrary.Entities.Insurables;
//using HexiSureClassLibrary.Entities.Insurances;

namespace HexiSure.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InsuranceService _service;
        InsuranceRepository _repository;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = "Server=.\\SQLEXPRESS;Database=HexiSureDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            _repository = new InsuranceRepository(connectionString);
            _service = new InsuranceService(_repository);
            MunicipalityComboBox.ItemsSource = _service.GetMunicipalities().OrderBy(m => m.Name).OrderBy(m => m.Code);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            PoliciesDataGrid.ItemsSource = _service.GetAllInsurances();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            MunicipalityComboBox.SelectedIndex = -1;
            MunicipalityFilterTextBox.Clear();
            AddressTextBox.Clear();
            TypeComboBox.SelectedIndex = -1;
            BuildDatePicker.SelectedDate = null;
            LivingAreaTextBox.Clear();
            MarketValueTextBox.Clear();
            AddFireCheckBox.IsChecked = false;
            AddTheft10KCheckBox.IsChecked = false;
            AddTheft30KCheckBox.IsChecked = false;
            AddLegalAidCheckBox.IsChecked = false;
            BasePremiumTextBox.Clear();
        }

        private void ShowToast(string message)
        {
            TagBorder.Tag = "Visible";
            TagTextBlock.Text = message;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(2);
            dispatcherTimer.Tick += (sender, e) =>
            {
                TagBorder.Tag = "Hidden"; dispatcherTimer.Stop();
            };
            dispatcherTimer.Start();
        }

        private void CreateHomePolicyButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: controleer of de gegevens geldig zijn
            bool basePremiumBool = double.TryParse(BasePremiumTextBox.Text, out double basePremium);
            bool marketValueBool = double.TryParse(MarketValueTextBox.Text, out double marketValue);
            bool livingAreaBool = double.TryParse(LivingAreaTextBox.Text, out double livingArea);
            bool datePicker = BuildDatePicker.SelectedDate != null;
            bool municipality = MunicipalityComboBox.SelectedValue != null;
            bool type = TypeComboBox.SelectedValue != null;
            bool adres = string.IsNullOrWhiteSpace(AddressTextBox.Text);
            bool theftcheck = AddTheft10KCheckBox.IsChecked == AddTheft30KCheckBox.IsChecked == true;
            if (basePremiumBool && marketValueBool && livingAreaBool && datePicker && municipality && type && theftcheck)
            {
                Residence residence = new Residence(AddressTextBox.Text, (DateTime)BuildDatePicker.SelectedDate, livingArea, marketValue, (Municipality)MunicipalityComboBox.SelectedValue, TypeComboBox.SelectedValue.ToString());
                HomeInsurance homeInsurance = new HomeInsurance(basePremium, _repository.GetNextPolicyNumber(), residence);

                if (AddFireCheckBox.IsChecked == true) homeInsurance.AddHomeFireInsurance();
                if (AddTheft10KCheckBox.IsChecked == true) homeInsurance.AddTheftInsurance10K();
                if (AddTheft30KCheckBox.IsChecked == true) homeInsurance.AddTheftInsurance30K();
                if (AddLegalAidCheckBox.IsChecked == true) homeInsurance.AddLegalAid();

                _service.AddInsurance(homeInsurance);

                ShowToast("✓ Nieuwe polis toegevoegd " + homeInsurance.ToString());
                ClearForm();
            }
            else
            {
                ShowToast("⚠ Ongeldige gegevens");
            }
        }

        private void MunicipalityFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MunicipalityComboBox.ItemsSource = _service.GetMunicipalities().OrderBy(m => m.Name).OrderBy(m => m.Code).Where(m => m.Name.Contains(MunicipalityFilterTextBox.Text));
        }

    }
}