using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Domain
{
    public class Motorcycle: Vehicle, IInsurable
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }

        public Motorcycle()
        {
            
        }

        public Motorcycle(int id, string licenseplate, string brand, string model, int year,
                decimal dailyRate, int engineCapacity, bool hasSideCar)
        {
            Id = id;
            LicensePlate = licenseplate;
            Brand = brand;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            EngineCapacity = engineCapacity;
            HasSidecar = hasSideCar;
        }

        public decimal CalculateInsuranceCost(int days)
        {
            decimal baseCost = 20m * days;
            if (EngineCapacity > 600)
                baseCost *= 1.5m; // Hoger risico = hogere kost
            return baseCost;
        }

        public override decimal CalculateRentalCost(int days)
        {
            decimal cost = DailyRate * days;
            // Toeslag voor krachtige motoren
            if (EngineCapacity > 600)
                cost *= 1.2m; // 20% toeslag
            return cost;
        }

        public override string GetDetails()
        {
            string sidecarInfo = HasSidecar ? "with sidecar" : "no sidecar";
            return $"{Brand} {Model} ({Year}) - {EngineCapacity}cc, {sidecarInfo}";
        }

        public string GetInsuranceType()
        {
            return EngineCapacity>600 ? "Premium Motorcycle Insurance" : "Standard Motorcycle Insurance";
        }

        public override string GetVehicleType()
        {
            return "Motorcycle";
        }
    }
}
