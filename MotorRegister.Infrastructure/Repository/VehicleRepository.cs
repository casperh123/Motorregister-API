using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Models;
using MotorRegister.Core.Repository;
using MotorRegister.Infrastrucutre.Database;
using System.Threading.Tasks;

namespace MotorRegister.Infrastrucutre.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MotorRegisterDbContext _database;

        public VehicleRepository(MotorRegisterDbContext database)
        {
            _database = database;
        }

        public async Task SaveVehicle(Vehicle xmlVehicle)
        {
            await _database.AddAsync(xmlVehicle);
            await _database.SaveChangesAsync();
        }

        public async Task<Vehicle?> GetVehicleByLicensePlate(string licensePlate)
        {
            return await _database.Vehicles.FindAsync(licensePlate);
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            // Ensure VehicleUsage reference
            if (vehicle.Usage != null)
            {
                vehicle.Usage = await GetOrAddEntityAsync(vehicle.Usage, u => u.Id == vehicle.Usage.Id);
                vehicle.UsageId = vehicle.Usage.Id;
            }

            // Ensure VehicleInformation reference
            if (vehicle.Information != null)
            {
                vehicle.Information = await GetOrAddEntityAsync(vehicle.Information, i => i.ChassisNumber == vehicle.Information.ChassisNumber);
                vehicle.InformationId = vehicle.Information.Id;
            }

            // Ensure InspectionResults references
            for (int i = 0; i < vehicle.InspectionResults.Count; i++)
            {
                var inspectionResult = vehicle.InspectionResults[i];
                vehicle.InspectionResults[i] = await GetOrAddEntityAsync(inspectionResult, ir => ir.VehicleId == inspectionResult.VehicleId && ir.Date == inspectionResult.Date);
            }

            // Ensure Permissions references
            for (int i = 0; i < vehicle.Permissions.Count; i++)
            {
                var permit = vehicle.Permissions[i];
                vehicle.Permissions[i] = await GetOrAddEntityAsync(permit, p => p.ValidFrom == permit.ValidFrom && p.Comment == permit.Comment && p.PermitTypeId == permit.PermitTypeId);
            }

            // Add or update the Vehicle
            var existingVehicle = await _database.Vehicles
                .FirstOrDefaultAsync(v => v.Id == vehicle.Id);

            if (existingVehicle != null)
            {
                _database.Entry(existingVehicle).CurrentValues.SetValues(vehicle);
                _database.Entry(existingVehicle).State = EntityState.Modified;
            }
            else
            {
                _database.Vehicles.Add(vehicle);
            }

            await _database.SaveChangesAsync();
        }

        private async Task<T> GetOrAddEntityAsync<T>(T entity, Expression<Func<T, bool>> predicate) where T : class
        {
            var existingEntity = await _database.Set<T>().FirstOrDefaultAsync(predicate);
            if (existingEntity != null)
            {
                _database.Entry(existingEntity).State = EntityState.Detached;
                _database.Entry(existingEntity).CurrentValues.SetValues(entity);
                _database.Entry(existingEntity).State = EntityState.Unchanged;
                return existingEntity;
            }
            else
            {
                _database.Set<T>().Add(entity);
                return entity;
            }
        }
    }
}
