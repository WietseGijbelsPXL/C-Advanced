using Dapper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Domain;
using VehicleRentalSystem.Infrastructure.Interfaces;

namespace VehicleRentalSystem.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        DbConnectionFactory _DbConnectionFactory;

        public VehicleRepository(DbConnectionFactory dbConnectionFactory)
        {
            _DbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> AddAsync(Vehicle vehicle)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                string type = vehicle.GetVehicleType();

                switch (type)
                {
                    case "Car":
                        Car car = (Car)vehicle;
                        return conn.Execute(@"INSERT INTO Vehicles
                (LicensePlate, Brand, Model, Year, DailyRate, IsAvailable, VehicleType, NumberOfDoors, FuelType)
                VALUES (@LicensePlate, @Brand, @Model, @Year, @DailyRate, @IsAvailable, @VehicleType, @NumberOfDoors, @FuelType);
                SELECT CAST(SCOPE_IDENTITY() AS INT)",
                new
                {
                    LicensePlate = vehicle.LicensePlate,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    DailyRate = vehicle.DailyRate,
                    IsAvailable = vehicle.IsAvailable,
                    VehicleType = vehicle.GetVehicleType(),
                    NumberOfDoors = car.NumberOfDoors,
                    FuelType = car.FuelType
                });
                    case "Motorcycle":
                        Motorcycle motorcycle = (Motorcycle)vehicle;
                        return conn.Execute(@"INSERT INTO Vehicles
                (LicensePlate, Brand, Model, Year, DailyRate, IsAvailable, VehicleType, EngineCapacity, HasSidecar)
                VALUES (@LicensePlate, @Brand, @Model, @Year, @DailyRate, @IsAvailable, @VehicleType, @EngineCapacity, @HasSidecar);
                SELECT CAST(SCOPE_IDENTITY() AS INT)",
                new
                {
                    LicensePlate = vehicle.LicensePlate,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    DailyRate = vehicle.DailyRate,
                    IsAvailable = vehicle.IsAvailable,
                    VehicleType = vehicle.GetVehicleType(),
                    EngineCapacity = motorcycle.EngineCapacity,
                    HasSidecar = motorcycle.HasSidecar
                });
                    case "Truck":
                        Truck truck = (Truck)vehicle;
                        return conn.Execute(@"INSERT INTO Vehicles
                (LicensePlate, Brand, Model, Year, DailyRate, IsAvailable, VehicleType, LoadCapacity, NumberOfAxles)
                VALUES (@LicensePlate, @Brand, @Model, @Year, @DailyRate, @IsAvailable, @VehicleType, @LoadCapacity, @NumberOfAxles);
                SELECT CAST(SCOPE_IDENTITY() AS INT)",
                new
                {
                    LicensePlate = vehicle.LicensePlate,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    DailyRate = vehicle.DailyRate,
                    IsAvailable = vehicle.IsAvailable,
                    VehicleType = vehicle.GetVehicleType(),
                    LoadCapacity = truck.LoadCapacity,
                    NumberOfAxles = truck.NumberOfAxles
                });
                    default:
                        throw new Exception("Not a known vehicle type.");
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute("DELETE FROM Vehicles WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                var vehicles = conn.Query<dynamic>("SELECT * FROM Vehicles");
                return vehicles.Select(MapToVehicle);

            }
        }

        public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync()
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                var vehicles = conn.Query<dynamic>("SELECT * FROM Vehicles WHERE IsAvailable = 1");
                return vehicles.Select(MapToVehicle);
            }
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                return MapToVehicle(conn.Query<dynamic>("SELECT * FROM Vehicles WHERE Id = @Id", new { Id = id }).FirstOrDefault());
            }
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            using (IDbConnection conn = _DbConnectionFactory.CreateConnection())
            {
                conn.Execute(@"UPDATE Vehicles SET
            LicensePlate = @LicensePlate, Brand = @Brand, Model = @Model,
            Year = @Year, DailyRate = @DailyRate, IsAvailable = @IsAvailable
            WHERE Id = @Id",
            new
            {
                LicensePlate = vehicle.LicensePlate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                DailyRate = vehicle.DailyRate,
                IsAvailable = vehicle.IsAvailable,
                Id = vehicle.Id
            });
            }
        }

        private Vehicle MapToVehicle(dynamic result)
        {
            string vehicleType = result.VehicleType;

            switch (vehicleType)
            {
                case "Car":
                    return new Car()
                    {
                        Id = result.Id,
                        LicensePlate = result.LicensePlate,
                        Brand = result.Brand,
                        Model = result.Model,
                        Year = result.Year,
                        DailyRate = result.DailyRate,
                        IsAvailable = result.IsAvailable,
                        NumberOfDoors = result.NumberOfDoors,
                        FuelType = result.FuelType,
                    };
                case "Motorcycle":
                    return new Motorcycle()
                    {
                        Id = result.Id,
                        LicensePlate = result.LicensePlate,
                        Brand = result.Brand,
                        Model = result.Model,
                        Year = result.Year,
                        DailyRate = result.DailyRate,
                        IsAvailable = result.IsAvailable,
                        EngineCapacity = result.EngineCapacity,
                        HasSidecar = result.HasSidecar,
                    };
                case "Truck":
                    return new Truck()
                    {
                        Id = result.Id,
                        LicensePlate = result.LicensePlate,
                        Brand = result.Brand,
                        Model = result.Model,
                        Year = result.Year,
                        DailyRate = result.DailyRate,
                        IsAvailable = result.IsAvailable,
                        LoadCapacity = result.LoadCapacity,
                        NumberOfAxles = result.NumberOfAxles,
                    };
                default:
                    throw new InvalidOperationException($"Unknown vehicle type: {vehicleType}");
            }
            ;
        }
    }
}

