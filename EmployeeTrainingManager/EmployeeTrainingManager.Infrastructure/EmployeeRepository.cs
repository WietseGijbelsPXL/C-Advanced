using Dapper;
using EmployeeTrainingManager.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Infrastructure
{
    public class EmployeeRepository
    {
        DbConnectionFactory _DbConnectionFactory;

        public EmployeeRepository(DbConnectionFactory dbConnectionFactory)
        {
            _DbConnectionFactory = dbConnectionFactory;
        }

        public IEnumerable<Employee> GetAllAsync()
        {
            using( IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Employee>("SELECT Id, FirstName, LastName FROM Employees");
            }
        }

        public Employee GetByIdAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Employee>("SELECT Id, FirstName, LastName FROM Employees WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void AddAsync(Employee employee)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("INSERT INTO Employees (FirstName, LastName) VALUES (@FirstName, @LastName); SELECT CAST(SCOPE_IDENTITY() as int)",
                    new { FirstName = employee.FirstName, LastName = employee.LastName });
            }
        }

        public void UpdateAsync(Employee employee)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("UPDATE Employees SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id",
                    new { FirstName = employee.FirstName, LastName = employee.LastName, Id = employee.Id });
            }
        }

        public void DeleteAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("DELETE FROM Employees WHERE Id = @Id",
                    new { Id = id });
            }
        }
    }
}
