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
        private readonly List<Appointment> _appointments = new List<Appointment>();

        public SchedulerRepository()
        {
            _rooms = new List<Room>();
            _rooms.Add(new Room("Vergaderzaal1", 15));
            _rooms.Add(new Room("Vergaderzaal2", 15));
            _rooms.Add(new Room("Vergaderzaal3", 15));
            _rooms.Add(new Room("Privé lokaal", 5));
            _rooms.Add(new Room("Aula", 60));
            _appointments.Add(new Appointment("Teamoverleg", new DateTime(2027, 6, 20, 10, 0, 0), new DateTime(2027, 6, 20, 11, 0, 0), 10, _rooms[0]));
            _appointments.Add(new Appointment("Projectbespreking", new DateTime(2027, 6, 20, 11, 0, 0), new DateTime(2027, 6, 20, 12, 0, 0), 8, _rooms[1]));
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

        public void CancelAppointment(Appointment appointment)
        {
            _appointments.Find(app => app == appointment).IsCancelled = true;
        }
    }
}
