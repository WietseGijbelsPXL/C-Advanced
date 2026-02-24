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
            return _schedulerRepository.GetAllAppointments().Where((app) => app.Room == room).ToList();
        }

        public List<Appointment> GetAppointmentsForDay(DateTime day)
        {
            return _schedulerRepository.GetAllAppointments().Where((app) => app.StartTime == day).ToList();
        }

        public void AddAppointment(string title, DateTime startTime, DateTime endTime, int participantsCount, Room room)
        {
            _schedulerRepository.AddAppointment(new Appointment(title, startTime, endTime, participantsCount, room));
        }

        //cancelappointment
    }
}
