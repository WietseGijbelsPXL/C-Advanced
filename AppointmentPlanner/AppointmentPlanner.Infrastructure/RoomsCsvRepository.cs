using AppointmentPlanner.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentPlanner.Infrastructure
{
    public class RoomsCsvRepository
    {
        public bool IsSaved { get; set; } = true;
        List<Room> _rooms;

        public RoomsCsvRepository()
        {
            _rooms = new List<Room>();
            Import();
        }

        public void Import()
        {
            using (StreamReader sr = new StreamReader("rooms.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] values = line.Split(';');

                    Room room = new Room(values[1], int.Parse(values[2]));
                    room.Number = Guid.Parse(values[0]);

                    _rooms.Add(room);
                }
            }

        }

        public void Save()
        {

            using (StreamWriter sw = new StreamWriter("rooms.csv"))
            {
                foreach (Room room in _rooms)
                {
                    string line = $"{room.Number};{room.Name};{room.MaxCapacity}";
                    sw.WriteLine(line);
                }
            }
            IsSaved = true;
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
            IsSaved = false;
        }

        public List<Room> GetAllRooms()
        {
            return new List<Room>(_rooms);
        }
    }
}
