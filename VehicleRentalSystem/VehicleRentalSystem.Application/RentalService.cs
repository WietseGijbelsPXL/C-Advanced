using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Domain;
using VehicleRentalSystem.Infrastructure.Interfaces;

namespace VehicleRentalSystem.Application
{
    public class RentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalService(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _rentalRepository = rentalRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> CreateRentalAsync(int customerId, int vehicleId,
            DateTime startDate, DateTime endDate)
        {
            Customer? customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            Vehicle? vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);
            if (vehicle == null)
                throw new InvalidOperationException("Vehicle not found");

            if (!vehicle.IsAvailable)
                throw new InvalidOperationException("Vehicle is not available");

            int days = (endDate - startDate).Days;
            decimal totalCost = vehicle.CalculateRentalCost(days); // Polymorfisme!

            Rental rental = new Rental(0, customerId, vehicleId, startDate, endDate, totalCost);
            int rentalId = await _rentalRepository.AddAsync(rental);

            // Markeer voertuig als niet beschikbaar
            vehicle.IsAvailable = false;
            await _vehicleRepository.UpdateAsync(vehicle);

            return rentalId;
        }

        // Polymorfisme: Werkt met IInsurable interface
        public decimal CalculateInsuranceCost(Vehicle vehicle, int days)
        {
            if (vehicle is IInsurable insurable)
            {
                return insurable.CalculateInsuranceCost(days);
            }
            return 0m; // Trucks hebben geen verzekering
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _rentalRepository.GetAllAsync();
        }
    }
}
