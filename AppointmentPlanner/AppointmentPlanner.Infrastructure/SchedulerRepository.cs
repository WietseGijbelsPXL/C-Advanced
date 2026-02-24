using AppointmentPlanner.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentPlanner.Infrastructure
{
    public class SchedulerRepository
    {
        private readonly List<Room> _rooms;
        private readonly List<Appointment> _appointments;

        public SchedulerRepository()
        {
            Room room1 = new Room("Vergaderzaal1", 15);
            Room room2 = new Room("Vergaderzaal2", 15);
            Room room3 = new Room("Vergaderzaal3", 15);
            Room room4 = new Room("Privé lokaal", 5);
            Room room5 = new Room("Aula", 60);
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return new List<Appointment>(_appointments);
        }

        public List<Room> GetAllRooms()
        {
            return new List<Room>(_rooms);
        }
    }
}
