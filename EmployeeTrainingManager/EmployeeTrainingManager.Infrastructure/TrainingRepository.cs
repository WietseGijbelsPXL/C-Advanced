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
    public class TrainingRepository
    {
        DbConnectionFactory _DbConnectionFactory;

        public TrainingRepository(DbConnectionFactory dbConnectionFactory)
        {
            _DbConnectionFactory = dbConnectionFactory;
        }

        public IEnumerable<Training> GetAllAsync()
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Training>("SELECT Id, Title, TrainerName, DurationInHours, TrainingType, Technology, RiskLevel FROM Trainings");
            }
        }

        public Training GetByIdAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return conn.Query<Training>("SELECT Id, Title, TrainerName, DurationInHours, TrainingType, Technology, RiskLevel FROM Trainings WHERE Id = @Id",
                    new { Id = id }).FirstOrDefault();
            }
        }

        public void AddAsync(Training training)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                if (training is TechnicalTraining)
                {
                    conn.Execute("INSERT INTO Trainings (Id, Title, TrainerName, DurationInHours, TrainingType, Technology) " +
                        "VALUES (@Id, @Title, @TrainerName, @DurationInHours, 'Technical', @Technology)");
                }
                else
                {
                    conn.Execute("INSERT INTO Trainings (Id, Title, TrainerName, DurationInHours, TrainingType, RiskLevel) " +
                        "VALUES (@Id, @Title, @TrainerName, @DurationInHours, 'Safety', @RiskLevel)");
                }
            }
        }

        public void UpdateAsync(Training training)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                if (training is TechnicalTraining)
                {
                    conn.Execute("UPDATE Trainings SET Title = @Title, TrainerName = @TrainerName, DurationInHours = @DurationInHours, Technology = @Technology WHERE Id = @Id");
                }
                else
                {
                    conn.Execute("UPDATE Trainings SET Title = @Title, TrainerName = @TrainerName, DurationInHours = @DurationInHours, RiskLevel = @RiskLevel WHERE Id = @Id");
                }
            }
        }

        public void DeleteAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("DELETE FROM Trainings WHERE Id = @Id");
            }
        }
    }
}
