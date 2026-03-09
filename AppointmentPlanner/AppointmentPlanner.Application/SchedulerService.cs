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
        private readonly SchedulerRepository _schedulerRepository;

        public SchedulerService()
        {
            _schedulerRepository = new SchedulerRepository();
        }

        public List<Room> GetAllRooms()
        {
            return _schedulerRepository.GetAllRooms();
        }

        public List<Appointment> GetAllAppointment()
        {
            return _schedulerRepository.GetAllAppointments();
        }

        public List<Appointment> GetAppointmentsForRoom(Room room)
        {
            return _schedulerRepository.GetAllAppointments().FindAll((app) => app.Room == room);
        }

        public List<Appointment> GetAppointmentsForDay(DateTime day)
        {
            return _schedulerRepository.GetAllAppointments().FindAll((app) => app.StartTime.Date == day.Date);
        }

        public void AddAppointment(string title, DateTime startTime, DateTime endTime, int participantsCount, Room room)
        {
            if (GetAppointmentsForRoom(room).Where((app) => (app.StartTime < endTime && app.StartTime > startTime) 
            || (app.EndTime > startTime && app.EndTime < endTime)) == null)
            {
                if (room.MaxCapacity > participantsCount)
                {
                    _schedulerRepository.AddAppointment(new Appointment(title, startTime, endTime, participantsCount, room));
                }
            }
        }

        public void CancelAppointment(Appointment appointment)
        {
            if (appointment.StartTime < DateTime.Now) throw new ArgumentException("Gestarte vegaderingen kunnen niet geannuleerd worden.");
            _schedulerRepository.CancelAppointment(appointment);
        }
    }
}
