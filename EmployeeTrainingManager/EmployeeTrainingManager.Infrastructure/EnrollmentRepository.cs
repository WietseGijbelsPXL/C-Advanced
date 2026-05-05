using Dapper;
using EmployeeTrainingManager.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Infrastructure
{
    public class EnrollmentRepository
    {
        DbConnectionFactory _DbConnectionFactory;
        EmployeeRepository _EmployeeRepository;
        TrainingRepository _TrainingRepository;

        public EnrollmentRepository(DbConnectionFactory connectionFactory, EmployeeRepository employeeRepository, TrainingRepository trainingRepository)
        {
            _DbConnectionFactory = connectionFactory;
            _EmployeeRepository = employeeRepository;
            _TrainingRepository = trainingRepository;
        }

        public IEnumerable<Enrollment> GetAllAsync()
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Enrollment>("SELECT Id, EmployeeId, TrainingId, IsBillable FROM Enrollments");
            }
        }

        public Enrollment GetByIdAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Enrollment>("SELECT Id, EmployeeId, TrainingId, IsBillable FROM Enrollments WHERE Id = @Id",
                    new {Id = id}).FirstOrDefault();
            }
        }

        public IEnumerable<Enrollment> GetByEmployeeIdAsync(int employeeId)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Enrollment>("SELECT Id, EmployeeId, TrainingId, IsBillable FROM Enrollments WHERE EmployeeId = @EmployeeId",
                    new { EmployeeId = employeeId });
            }
        }

        public void AddAsync(Enrollment enrollment)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("INSERT INTO Enrollments (EmployeeId, TrainingId, IsBillable)" +
                    "VALUES (@EmployeeId, @TrainingId, @IsBillable); SELECT CAST(SCOPE_IDENTITY() as int)",
                    new {EmployeeId = enrollment.Employee.Id, TrainingId = enrollment.Training.Id, IsBillable = enrollment.IsBillable.ToString() });
            }
        }

        public void UpdateAsync(Enrollment enrollment)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("UPDATE Enrollments SET EmployeeId = @EmployeeId, TrainingId = @TrainingId, IsBillable = @IsBillable WHERE Id = @Id",
                    new { EmployeeId = enrollment.Employee.Id, TrainingId = enrollment.Training.Id, IsBillable = enrollment.IsBillable.ToString(), Id = enrollment.Id });
            }
        }

        public void DeleteAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("DELETE FROM Enrollments WHERE Id = @Id",
                    new {Id = id});
            }
        }
    }
}
