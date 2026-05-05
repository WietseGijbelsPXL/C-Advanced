using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Domain;
using VehicleRentalSystem.Infrastructure.Interfaces;

namespace VehicleRentalSystem.Application
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> AddCarAsync(string licensePlate, string brand,
            string model, int year, decimal dailyRate, int numberOfDoors, string fuelType)
        {
            Car car = new Car(0, licensePlate, brand, model, year,
                dailyRate, numberOfDoors, fuelType);
            return await _vehicleRepository.AddAsync(car);
        }

        public async Task<int> AddMotorcycleAsync(string licensePlate, string brand,
            string model, int year, decimal dailyRate, int engineCapacity, bool hasSidecar)
        {
            Motorcycle motorcycle = new Motorcycle(0, licensePlate, brand, model, year,
                dailyRate, engineCapacity, hasSidecar);
            return await _vehicleRepository.AddAsync(motorcycle);
        }

        public async Task<int> AddTruckAsync(string licensePlate, string brand,
            string model, int year, decimal dailyRate, decimal loadCapacity, int numberOfAxles)
        {
            Truck truck = new Truck(0, licensePlate, brand, model, year,
                dailyRate, loadCapacity, numberOfAxles);
            return await _vehicleRepository.AddAsync(truck);
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllAsync();
        }
    }
}
