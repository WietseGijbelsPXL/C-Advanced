using AppointmentPlanner.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppointmentPlanner.Infrastructure
{
    public class AppointmentsJsonRepository
    {
        public bool IsSaved { get; set; }
        List<Appointment> _appointments;

        public AppointmentsJsonRepository()
        {
            Import();
        }

        public void Import()
        {
            string content = File.ReadAllText("appointments.json");
            _appointments = JsonSerializer.Deserialize<List<Appointment>>(content);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
            IsSaved = false;
        }

        public void CancelAppointment(Appointment appointment)
        {
            _appointments.Find(app => app == appointment).IsCancelled = true;
            IsSaved = false;
        }

        public void Save()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string content = JsonSerializer.Serialize(_appointments,options);
            File.WriteAllText("appointments.json", content);
            IsSaved = true;
        }
    }
}
