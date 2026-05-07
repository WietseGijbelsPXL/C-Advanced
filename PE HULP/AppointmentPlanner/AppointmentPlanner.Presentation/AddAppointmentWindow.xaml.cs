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
    /// Interaction logic for AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {
        SchedulerService _schedulerService;

        public AddAppointmentWindow(SchedulerService schedulerService)
        {
            InitializeComponent();
            _schedulerService = schedulerService;
            FillRoomsComboBox();

            for(int i = 0; i < 24; i++)
            {
                startHourComboBox.Items.Add(i.ToString());
                endHourComboBox.Items.Add(i.ToString());
            }
            for(int i = 0; i < 60; i++)
            {
                startMinuteComboBox.Items.Add(i.ToString());
                endMinuteComboBox.Items.Add(i.ToString());
            }
        }

        private void FillRoomsComboBox()
        {
            roomComboBox.ItemsSource = _schedulerService.GetAllRooms();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = new DateTime(startDatePicker.SelectedDate.Value.Year, startDatePicker.SelectedDate.Value.Month, startDatePicker.SelectedDate.Value.Day, int.Parse(startHourComboBox.SelectedValue.ToString()), int.Parse(startMinuteComboBox.SelectedValue.ToString()), 0);
            DateTime end = new DateTime(endDatePicker.SelectedDate.Value.Year, endDatePicker.SelectedDate.Value.Month, endDatePicker.SelectedDate.Value.Day, int.Parse(endHourComboBox.SelectedValue.ToString()), int.Parse(endMinuteComboBox.SelectedValue.ToString()), 0);
            _schedulerService.AddAppointment(titleTextBox.Text, start, end, int.Parse(numberOfParticipantsTextBox.Text), (Room)roomComboBox.SelectedValue);
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
