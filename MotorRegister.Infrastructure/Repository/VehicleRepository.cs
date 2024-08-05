using MotorRegister.Core.Models;
using MotorRegister.Core.Repository;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

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
        //await _database.BulkInsertAsync(vehicles);

        foreach (Vehicle vehicle in vehicles)
        {
            _database.ChangeTracker.Clear();
            await _database.AddAsync(vehicle);
            await _database.SaveChangesAsync();
        }
    }
}