using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Models;
using MotorRegister.Core.Repository;

namespace MotorRegister.Infrastrucutre.Repository;

public class VehicleRepository : IVehicleRepository
{
    private MotorRegisterDbContext _database;

    public VehicleRepository(MotorRegisterDbContext database)
    {
        _database = database;
    }

    public async Task SaveVehicle(Vehicle vehicle)
    {
        await _database.AddAsync(vehicle);
        await _database.SaveChangesAsync();
    }

    public async Task<Vehicle?> GetVehicleByLicensePlate(string licensePlate)
    {
        return await _database.Vehicles.FindAsync(licensePlate);
    }
}