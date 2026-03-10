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
        public void Import()
        {
            string content = File.ReadAllText("appointments.json");
            var appointments = JsonSerializer.Deserialize<List<Appointment>>(content);
        }
    }
}
