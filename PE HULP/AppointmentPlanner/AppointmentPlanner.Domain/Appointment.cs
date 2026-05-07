using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentPlanner.Domain
{
    public class Appointment
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Titel maag niet leeg zijn.");
                title = value;
            }
        }

        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                if (value.TimeOfDay < new TimeSpan(8, 0, 0) || value.TimeOfDay > new TimeSpan(20, 0, 0)) throw new ArgumentOutOfRangeException("Start tijd moet tussen 8 en 20 uur liggen.");
                startTime = value;
            }
        }

        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                if (value <= StartTime) throw new ArgumentOutOfRangeException("Start tijd moet voor eind tijd liggen.");
                if (value.TimeOfDay <= new TimeSpan(8, 0, 0) || value.TimeOfDay >= new TimeSpan(20, 0, 0)) throw new ArgumentOutOfRangeException("Eind tijd moet tussen 8 en 20 uur liggen.");
                endTime = value;
            }
        }

        private int participantsCount;

        public int ParticipantsCount
        {
            get { return participantsCount; }
            set
            {
                if (value <= 0) throw new Exception("Aantal deelnemers moet groter zijn dan 0.");
                participantsCount = value;
            }
        }

        public Room Room { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime CreatedAt { get; set; }

        //duration niet apart opgeslagen???
        public TimeSpan Duration => endTime - startTime;

        public Appointment(string title, DateTime startTime, DateTime endTime, int participantsCount, Room room)
        {
            Title = title;
            StartTime = startTime;
            EndTime = endTime;
            ParticipantsCount = participantsCount;
            Room = room;
            IsCancelled = false;
            CreatedAt = DateTime.Now;
        }

        override public string ToString()
        {
            return $"[{Room}] {title} - {Duration} {(IsCancelled ? "Geanuleerd" : "")}";
        }
    }
}
