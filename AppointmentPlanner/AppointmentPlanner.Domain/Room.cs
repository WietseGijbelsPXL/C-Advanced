using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentPlanner.Domain
{
    public class Room
    {
        public Guid Number { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }

        public Room(string name, int maxCapacity)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Naam mag niet leeg zijn.");
            if (maxCapacity <= 0) throw new ArgumentOutOfRangeException("Max Capaciteit moet groter zijn dan 0.");
            Number = Guid.NewGuid();
            Name = name;
            MaxCapacity = maxCapacity;
        }
    }
}
