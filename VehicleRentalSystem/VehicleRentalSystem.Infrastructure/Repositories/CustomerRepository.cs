using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Domain;
using VehicleRentalSystem.Infrastructure.Interfaces;

namespace VehicleRentalSystem.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        DbConnectionFactory _DbConnectionFactory;

        public CustomerRepository(DbConnectionFactory dbConnectionFactory)
        {
            _DbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> AddAsync(Customer customer)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Execute(@"INSERT INTO Customers
                    (FirstName, LastName, Email, PhoneNumber, DriverLicenseNumber)
                    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @DriverLicenseNumber);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)",
                    new
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                        DriverLicenseNumber = customer.DriverLicenseNumber,
                    });
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("DELETE FROM Customers WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Customer>("SELECT * FROM Customers");
            }
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public async Task UpdateAsync(Customer customer)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute(@"UPDATE Customers SET
            FirstName = @FirstName, LastName = @LastName, Email = @Email,
            PhoneNumber = @PhoneNumber, DriverLicenseNumber = @DriverLicenseNumber
            WHERE Id = @Id",
            new
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                DriverLicenseNumber = customer.DriverLicenseNumber,
                Id = customer.Id
            });
            }
        }
    }
}
