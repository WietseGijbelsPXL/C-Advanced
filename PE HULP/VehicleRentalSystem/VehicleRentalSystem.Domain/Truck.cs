using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Domain
{
    public class Truck : Vehicle
    {
        public decimal LoadCapacity { get; set; }
        public int NumberOfAxles { get; set; }

        public Truck()
        {
            
        }

        public Truck(int id, string licenseplate, string brand, string model, int year,
                decimal dailyRate, decimal loadCapacity, int numberOfAxels)
        {
            Id = id;
            LicensePlate = licenseplate;
            Brand = brand;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            LoadCapacity = loadCapacity;
            NumberOfAxles = numberOfAxels;
        }

        public override decimal CalculateRentalCost(int days)
        {
            decimal cost = DailyRate * days;
            // Extra kost voor zware vrachtwagens
            if (LoadCapacity > 5000)
                cost += 50m * days;
            return cost;
        }

        public override string GetDetails()
        {
            return $"{Brand} {Model} ({Year}) - Capacity: {LoadCapacity}kg, {NumberOfAxles} axles";
        }

        public override string GetVehicleType()
        {
            return "Truck";
        }
    }
}
