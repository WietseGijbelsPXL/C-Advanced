using AppointmentPlanner.Application;
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
    /// Interaction logic for AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {
        private SchedulerService _schedulerService = new SchedulerService();

        public AddAppointmentWindow()
        {
            InitializeComponent();
            appointmentsListBox.ItemsSource = _schedulerService.GetAllAppointment();
            RoomComboBox.ItemsSource = _schedulerService.GetAllRooms();
        }

        private void addAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
