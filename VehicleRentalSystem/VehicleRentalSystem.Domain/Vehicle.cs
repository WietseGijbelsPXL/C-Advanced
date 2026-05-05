using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Domain
{
    public abstract class Vehicle
    {
        public int Id { get; set; }

        public string LicensePlate { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public decimal DailyRate { get; set; }

        public bool IsAvailable { get; set; }

        public abstract string GetVehicleType();

        public abstract decimal CalculateRentalCost(int days);

        public abstract string GetDetails();
    }
}
