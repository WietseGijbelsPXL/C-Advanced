using AppointmentPlanner.Domain;
using AppointmentPlanner.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentPlanner.Application
{
    public class SchedulerService
    {
        public bool AppointmentsSaved => _appointmentRepository.IsSaved && _roomsRepository.IsSaved;
        RoomsCsvRepository _roomsRepository;
        AppointmentsJsonRepository _appointmentRepository;

        public SchedulerService()
        {
            _roomsRepository = new RoomsCsvRepository();
            _appointmentRepository = new AppointmentsJsonRepository();
        }

        public List<Room> GetAllRooms()
        {
            return _roomsRepository.GetAllRooms();
        }

        public List<Appointment> GetAllAppointment()
        {
            return _appointmentRepository.GetAllAppointments();
        }

        public List<Appointment> GetAppointmentsForRoom(Room room)
        {
            return _appointmentRepository.GetAllAppointments().FindAll((app) => app.Room == room);
        }

        public List<Appointment> GetAppointmentsForDay(DateTime day)
        {
            return _appointmentRepository.GetAllAppointments().FindAll((app) => app.StartTime.Date == day.Date);
        }

        public void AddAppointment(string title, DateTime startTime, DateTime endTime, int participantsCount, Room room)
        {
            //if (GetAppointmentsForRoom(room).Where((app) => (app.StartTime < endTime && app.StartTime > startTime) 
            //|| (app.EndTime > startTime && app.EndTime < endTime)) == null)
            //{
            if (room.MaxCapacity > participantsCount)
            {
                _appointmentRepository.AddAppointment(new Appointment(title, startTime, endTime, participantsCount, room));
            }
            //}
        }

        public void CancelAppointment(Appointment appointment)
        {
            if (appointment.StartTime < DateTime.Now) throw new ArgumentException("Gestarte vegaderingen kunnen niet geannuleerd worden.");
            _appointmentRepository.CancelAppointment(appointment);
        }

        public void SaveAll()
        {
            _appointmentRepository.Save();
            _roomsRepository.Save();
        }

        public void AddRoom(string title, int maxCapacity)
        {
            _roomsRepository.AddRoom(new Room(title,maxCapacity));
        }
    }
}
