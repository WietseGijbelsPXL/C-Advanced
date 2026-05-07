using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Domain
{
    public class Car : Vehicle, IInsurable
    {
        public int NumberOfDoors { get; set; }
        public string FuelType { get; set; }

        public Car()
        {
            
        }

        public Car(int id, string licenseplate, string brand,string model,int year,
                decimal dailyRate,int numberOfDoors,string fuelType)
        {
            Id = id;
            LicensePlate = licenseplate;
            Brand = brand;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            NumberOfDoors = numberOfDoors;
            FuelType = fuelType;
        }

        public decimal CalculateInsuranceCost(int days)
        {
            return 15m;
        }

        public override decimal CalculateRentalCost(int days)
        {
            return DailyRate*days;
        }

        public override string GetDetails()
        {
            return $"{Brand} {Model} ({Year}) - {NumberOfDoors} doors, {FuelType}";
        }

        public string GetInsuranceType()
        {
            return "Standard Car Insurance";
        }

        public override string GetVehicleType()
        {
            return "Car";
        }
    }
}
