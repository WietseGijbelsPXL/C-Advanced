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
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ParticipantsCount { get; set; }
        public Room Room { get; set; }
        public bool IsCancelled { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //duration niet apart opgeslagen???
        public TimeSpan Duration { get; }

        public Appointment(string title, DateTime startTime, DateTime endTime, int participantsCount, Room room)
        {
            if(string.IsNullOrWhiteSpace(title))throw new ArgumentNullException("Titel maag niet leeg zijn.");
            if (endTime < startTime) throw new Exception("Eind tijd moet na start tijd vallen.");
            if (participantsCount <= 0) throw new Exception("Aantal deelnemers moet groter zijn dan 0.");
            if (startTime.Day != endTime.Day || startTime.Hour < 8 || endTime.Hour < 20) throw new Exception("De afspraak moet tussen 8 en 20 uur vallen");

            Title = title;
            StartTime = startTime;
            EndTime = endTime;
            ParticipantsCount = participantsCount;
            Room = room;
            Duration = endTime - startTime;
        }


    }
}
