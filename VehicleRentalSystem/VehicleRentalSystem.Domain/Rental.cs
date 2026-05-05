using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Domain
{
    public class Rental
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsActive { get; set; } = true;

        public Customer? Customer { get; set; }
        public Vehicle? Vehicle { get; set; }

        public Rental()
        {
            
        }

        public Rental(int id, int customerId, int vehicleId, DateTime startDate, DateTime endDate, decimal totalCost)
        {
            Id = id;
            CustomerId = customerId;
            VehicleId = vehicleId;
            StartDate = startDate;
            EndDate = endDate;
            TotalCost = totalCost;
            IsActive = true;
        }

        public int GetRentalDays()
        {
            return (EndDate - StartDate).Days;
        }
    }
}
