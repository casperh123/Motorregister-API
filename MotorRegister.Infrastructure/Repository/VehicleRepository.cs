using Microsoft.EntityFrameworkCore;
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

    public async Task SaveVehicle(XmlVehicle xmlVehicle)
    {
        await _database.AddAsync(xmlVehicle);
        await _database.SaveChangesAsync();
    }

    public async Task<XmlVehicle?> GetVehicleByLicensePlate(string licensePlate)
    {
        return await _database.Vehicles.FindAsync(licensePlate);
    }

    public async Task AddVehiclesAsync(List<XmlVehicle> vehicles)
    { 
        //await _database.BulkInsertAsync(vehicles);

        foreach (XmlVehicle vehicle in vehicles)
        {
            await _database.AddAsync(vehicle);
            await _database.SaveChangesAsync();
        }
    }
}