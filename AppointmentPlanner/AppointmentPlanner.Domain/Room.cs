using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppointmentPlanner.Domain
{
    public class Room
    {
        public Guid Number { get; set; }
        
        private string name;

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Naam mag niet leeg zijn.");
                }
                name = value;
            }
        }

        private int maxCapacity;

        public int MaxCapacity
        {
            get { return maxCapacity; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Max Capaciteit moet groter zijn dan 0.");
                maxCapacity = value;
            }
        }

        public Room(string name, int maxCapacity)
        {
            Number = Guid.NewGuid();
            Name = name;
            MaxCapacity = maxCapacity;
        }

        override public string ToString()
        {
            return Name;
        }
    }
}
