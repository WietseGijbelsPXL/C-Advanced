using AppointmentPlanner.Application;
using AppointmentPlanner.Domain;
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

namespace AppointmentPlanner.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SchedulerService _schedulerService = new SchedulerService();

        public MainWindow()
        {
            InitializeComponent();
            FillListBox();
            RoomComboBox.ItemsSource = _schedulerService.GetAllRooms();
        }

        private void FillListBox()
        {
            appointmentsListBox.ItemsSource = null;
            appointmentsListBox.ItemsSource = _schedulerService.GetAllAppointment();
        }

        private void addAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            AddAppointmentWindow addAppointmentWindow = new AddAppointmentWindow(_schedulerService);
            if(addAppointmentWindow.ShowDialog() == true)
            {
                FillListBox();
            }
        }

        private void cancelAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            _schedulerService.CancelAppointment((Appointment)appointmentsListBox.SelectedItem);
            FillListBox();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            FillListBox();
        }
    }
}
