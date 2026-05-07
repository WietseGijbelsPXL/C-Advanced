using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Domain;
using VehicleRentalSystem.Infrastructure.Interfaces;

namespace VehicleRentalSystem.Infrastructure.Repositories
{
    public class RentalRepository: IRentalRepository
    {
        DbConnectionFactory _DbConnectionFactory;
        ICustomerRepository _customerRepository;
        IVehicleRepository _vehicleRepository;

        public RentalRepository( DbConnectionFactory dbConnectionFactory, ICustomerRepository customerRepository, IVehicleRepository vehicleRepository)
        {
            _DbConnectionFactory = dbConnectionFactory;
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> AddAsync(Rental rental)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Execute(@"INSERT INTO Rentals
            (CustomerId, VehicleId, StartDate, EndDate, TotalCost, IsActive)
            VALUES (@CustomerId, @VehicleId, @StartDate, @EndDate, @TotalCost, @IsActive);
            SELECT CAST(SCOPE_IDENTITY() AS INT)",
            new
            {
                CustomerId = rental.CustomerId,
                VehicleId = rental.VehicleId,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                TotalCost = rental.TotalCost,
                IsActive = rental.IsActive
            });
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("DELETE FROM Rentals WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Rental>> GetActiveRentalsAsync()
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Rental>("Select * from rentals where IsActive = 1");
            }
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                var rentals = (await conn.QueryAsync<Rental>("SELECT * FROM Rentals")).ToList();
                await HydrateRentalsAsync(rentals);
                return rentals;
            }
        }

        public async Task<Rental?> GetByIdAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Rental>("SELECT * FROM Rentals WHERE Id = @Id", new {Id = id}).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Rental>> GetRentalsByCustomerIdAsync(int customerId)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Rental>("select * from rentals where CustomerId = @Id", new { Id = customerId });
            }
        }

        public async Task UpdateAsync(Rental rental)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute(@"UPDATE Rentals SET
            CustomerId = @CustomerId, VehicleId = @VehicleId,
            StartDate = @StartDate, EndDate = @EndDate,
            TotalCost = @TotalCost, IsActive = @IsActive
            WHERE Id = @Id",
            new
            {
                CustomerId = rental.CustomerId,
                VehicleId = rental.VehicleId,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                TotalCost = rental.TotalCost,
                IsActive = rental.IsActive,
                Id = rental.Id
            });
            }
        }

        private async Task HydrateRentalsAsync(List<Rental> rentals)
        {
            foreach (var rental in rentals)
            {
                rental.Customer = await _customerRepository.GetByIdAsync(rental.CustomerId);
                rental.Vehicle = await _vehicleRepository.GetByIdAsync(rental.VehicleId);
            }
        }
    }
}
