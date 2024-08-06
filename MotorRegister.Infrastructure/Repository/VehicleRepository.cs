using Microsoft.Extensions.Options;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;
using Z.EntityFramework.Extensions;

namespace MotorRegister.Infrastrucutre.Repository;

public class VehicleRepository : IVehicleRepository
{
    private MotorRegisterDbContext _database;

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

    public async Task AddVehiclesAsync(List<Vehicle> vehicles)
    {
        await _database.BulkInsertOptimizedAsync(vehicles, options =>
        {
            options.IncludeGraph = true;
            options.InsertIfNotExists = true;
        });
    }
}